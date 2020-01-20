
namespace RebelQuery.Models
{
    public class SqlQuery
    {
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

    }

}