using System;
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
        protected SqlQuery BuildAnQuery(string queryStr, object args =null)
        {
            this.QueryString = queryStr;

            return this;
        }
        protected SqlQuery BuildAnQuery(DQL command, object args =null)
        {
            this.QueryString = new StringBuilder("{command} {what} FROM {table} {Where}")
            .Replace("{command}", command.ToString())
            .Replace("{table}", this.GetType().Name)
            .Replace("{what}", BuildSelectArgs())
            .Replace("{Where}", BuildWhereArgs())
            .ToString();

            return this;
        }

        protected SqlQuery BuildAnQuery(DDL command, object args =null)
        {
            return new SqlQuery{
                QueryString = command.ToString()
            };
        }

        protected SqlQuery BuildAnQuery<T>(DML command, object args)
        {
            this.QueryString = new StringBuilder("{command} {table} SET {set} {Where}")
            .Replace("{command}", command.ToString())
            .Replace("{table}", this.GetType().Name)
            .Replace("{set}", BuildSetArgs<T>(args))
            .Replace("{Where}", BuildWhereArgs(true))
            .ToString();

            return this;
        }

        private string BuildSetArgs<T>(object args) =>
            IsValideArgs(args) ?
            string.Join(
                ", ",
                args
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance |BindingFlags.DeclaredOnly)
                .Where(o => o.GetCustomAttributes(typeof(PrimaryKey)).Any() == false)
                .Select(x =>  x.Name + "=" + SerializeSqlValue(x.GetValue(args)))
                ) : String.Empty;
        
        private string BuildSelectArgs() =>
            IsValideArgs(this.SelectArgs) ?
            string.Join( 
                ", ",
                this.SelectArgs
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance |BindingFlags.DeclaredOnly)
                .Select(x => x.Name)
                ) : "*";
                
        private string BuildWhereArgs(bool required = false) =>
            (IsValideArgs(this.WhereArgs) ?
            "WHERE " + 
            string.Join(
                " ",
                this.WhereArgs
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance |BindingFlags.DeclaredOnly)
                .Select(x => x.Name + x.GetValue(this.WhereArgs, null))
                ) : (required ? "WHERE " :  String.Empty));

        private bool IsValideArgs(object args) =>
        !(args == null || object.Equals(args, new{}) || object.Equals(args, String.Empty) || args.GetType().GetProperties().Count() <= 0 );
        
        private string SerializeSqlValue (object value) =>
        (value.GetType() == typeof(string) || value.GetType() == typeof(char)) ?
               ("'" + value + "'")
            : (value.GetType() == typeof(bool)) ?
                 ((bool)value ? "1" : "0")
            : value.ToString();
    }

}