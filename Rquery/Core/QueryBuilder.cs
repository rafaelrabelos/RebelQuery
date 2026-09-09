using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Linq;

namespace RebelQuery.Core
{
    using Models;

    /// <summary>
    /// QueryBuilder class 
    /// </summary>
    public class RQueryBuilder : SqlQuery
    {
        private static readonly string[] WhereOperators =
        {
            "IS NOT NULL", "IS NULL",
            "NOT LIKE", "LIKE",
            "NOT IN", "IN",
            ">=", "<=", "<>", "!=", "=", ">", "<"
        };

        protected SqlQuery BuildAnQuery(string queryStr, object args =null)
        {
            ClearParameters();
            this.QueryString = queryStr;
            if (IsValideArgs(args))
                BindExplicitParameters(args);

            return this;
        }

        protected SqlQuery BuildAnQuery(DQL command, object args =null)
        {
            ClearParameters();
            this.QueryString = new StringBuilder("{command} {what} FROM {table} {Where}")
            .Replace("{command}", command.ToString())
            .Replace("{table}", SafeIdentifier(this.GetType().Name))
            .Replace("{what}", BuildSelectArgs())
            .Replace("{Where}", BuildWhereArgs())
            .ToString();

            return this;
        }

        protected SqlQuery BuildAnQuery(DDL command, object args =null)
        {
            ClearParameters();
            return new SqlQuery{
                QueryString = command.ToString()
            };
        }

        protected SqlQuery BuildAnQuery<T>(DML command, object args)
        {
            ClearParameters();
            this.QueryString = new StringBuilder("{command} {table} SET {set} {Where}")
            .Replace("{command}", command.ToString())
            .Replace("{table}", SafeIdentifier(this.GetType().Name))
            .Replace("{set}", BuildSetArgs<T>(args))
            .Replace("{Where}", BuildWhereArgs(true))
            .ToString();

            return this;
        }

        private string BuildSetArgs<T>(object args) =>
            IsValideArgs(args) ?
            string.Join(
                ", ",
                this.GetProps(args)
                .Where(o => o.GetCustomAttributes(typeof(PrimaryKey)).Any() == false)
                .Select(x =>
                {
                    var column = SafeIdentifier(x.Name);
                    return column + "=" + AddParameter("rq_set_" + column, x.GetValue(args));
                })
                ) : String.Empty;
        
        private string BuildSelectArgs() =>
            IsValideArgs(this.SelectArgs) ?
            string.Join( 
                ", ",
                this.GetProps(this.SelectArgs)
                .Select(x => SafeIdentifier(x.Name))
                ) : "*";
                
        private string BuildWhereArgs(bool required = false) =>
            (IsValideArgs(this.WhereArgs) ?
            "WHERE " + 
            string.Join(
                " AND ",
                this.GetProps(this.WhereArgs)
                .Select(x => BuildWhereClause(SafeIdentifier(x.Name), x.GetValue(this.WhereArgs, null)))
                ) : (required ? "WHERE " :  String.Empty));

        private void BindExplicitParameters(object args)
        {
            foreach (var p in this.GetProps(args))
            {
                AddParameter(p.Name, p.GetValue(args, null));
            }
        }

        private string BuildWhereClause(string column, object raw)
        {
            if (raw == null)
                return column + " IS NULL";

            if (!(raw is string text))
                return column + " = " + AddParameter("rq_where_" + column, raw);

            text = text.Trim();
            foreach (var op in WhereOperators)
            {
                if (!text.StartsWith(op, StringComparison.OrdinalIgnoreCase))
                    continue;

                var rest = text.Substring(op.Length).Trim();
                if (IsNullOperator(op))
                    return column + " " + op;

                if (IsInOperator(op))
                    return BuildInClause(column, op, rest);

                return column + " " + op + " " + AddParameter("rq_where_" + column, CoerceWhereLiteral(Unquote(rest)));
            }

            return column + " = " + AddParameter("rq_where_" + column, CoerceWhereLiteral(Unquote(text)));
        }

        private string BuildInClause(string column, string op, string rest)
        {
            rest = rest.Trim();
            if (rest.StartsWith("(") && rest.EndsWith(")") && rest.Length >= 2)
                rest = rest.Substring(1, rest.Length - 2);

            var values = SplitSqlList(rest);
            if (values.Count == 0)
                throw new ArgumentException("IN/NOT IN requires at least one value.", nameof(rest));

            var placeholders = new List<string>(values.Count);
            for (var i = 0; i < values.Count; i++)
            {
                placeholders.Add(AddParameter("rq_where_" + column + "_" + i, CoerceWhereLiteral(Unquote(values[i]))));
            }

            return column + " " + op + " (" + string.Join(", ", placeholders) + ")";
        }

        private bool IsValideArgs(object args) =>
        !(args == null || object.Equals(args, new{}) || object.Equals(args, String.Empty) || args.GetType().GetProperties().Count() <= 0 );

        private PropertyInfo[] GetProps(object obj) => obj
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        private static bool IsNullOperator(string op) =>
            op.Equals("IS NULL", StringComparison.OrdinalIgnoreCase) ||
            op.Equals("IS NOT NULL", StringComparison.OrdinalIgnoreCase);

        private static bool IsInOperator(string op) =>
            op.Equals("IN", StringComparison.OrdinalIgnoreCase) ||
            op.Equals("NOT IN", StringComparison.OrdinalIgnoreCase);

        private static string SafeIdentifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || !(char.IsLetter(name[0]) || name[0] == '_'))
                throw new ArgumentException("Invalid SQL identifier: " + name, nameof(name));

            for (var i = 1; i < name.Length; i++)
            {
                if (!(char.IsLetterOrDigit(name[i]) || name[i] == '_'))
                    throw new ArgumentException("Invalid SQL identifier: " + name, nameof(name));
            }

            return name;
        }

        private static string Unquote(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            value = value.Trim();
            if (value.Length >= 2 &&
                ((value[0] == '\'' && value[value.Length - 1] == '\'') ||
                 (value[0] == '"' && value[value.Length - 1] == '"')))
            {
                return value.Substring(1, value.Length - 2).Replace("''", "'");
            }

            return value;
        }

        private static object CoerceWhereLiteral(string value)
        {
            if (value == null)
                return null;

            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i))
                return i;

            if (long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var l))
                return l;

            if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var d))
                return d;

            if (bool.TryParse(value, out var b))
                return b;

            if (value.IndexOfAny(new[] { '-', '/', ':' }) >= 0 &&
                DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var dt))
                return dt;

            return value;
        }

        private static List<string> SplitSqlList(string list)
        {
            var values = new List<string>();
            var current = new StringBuilder();
            var inQuote = false;

            foreach (var c in list)
            {
                if (c == '\'')
                {
                    inQuote = !inQuote;
                    current.Append(c);
                    continue;
                }

                if (c == ',' && !inQuote)
                {
                    var item = current.ToString().Trim();
                    if (item.Length > 0)
                        values.Add(item);
                    current.Clear();
                    continue;
                }

                current.Append(c);
            }

            var last = current.ToString().Trim();
            if (last.Length > 0)
                values.Add(last);

            return values;
        }
    }

}