using System;
using System.Collections.Generic;

namespace RebelQuery.Models
{
    public class SqlQuery
    {
        private readonly List<SqlQueryParameter> _parameters = new List<SqlQueryParameter>();

        /// <summary>
        /// A object containing supplied args to run a SELECT query.
        /// </summary>
        public object SelectArgs {get; set;}
        /// <summary>
        /// A object containing supplied WHERE args to run a SELECT query.
        /// </summary>
        public object WhereArgs {get; set;}
        /// <summary>
        /// A string containing the query to be executed.
        /// </summary>
        public string QueryString {get; set;}
        /// <summary>
        /// The Server connection string used to estabilish comunication.
        /// </summary>
        protected virtual string ConnectionString {get; set;}
        /// <summary>
        /// Returns the current connectionstring.
        /// </summary>
        public string GetConnectionString { get => this.ConnectionString; }

        /// <summary>
        /// Parameters bound to <see cref="QueryString"/> placeholders.
        /// </summary>
        public IReadOnlyList<SqlQueryParameter> Parameters => _parameters;

        protected void ClearParameters() => _parameters.Clear();

        protected string AddParameter(string name, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter name is required.", nameof(name));

            name = name[0] == '@' ? name : "@" + name;
            _parameters.RemoveAll(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            _parameters.Add(new SqlQueryParameter(name, value));
            return name;
        }
    }
}