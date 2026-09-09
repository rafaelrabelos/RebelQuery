namespace RebelQuery.Models
{
    /// <summary>
    /// A value bound to a SQL parameter placeholder.
    /// </summary>
    public sealed class SqlQueryParameter
    {
        public SqlQueryParameter(string name, object value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Parameter name, including the leading '@'.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value sent to SQL Server. Null is sent as DBNull.
        /// </summary>
        public object Value { get; }
    }
}
