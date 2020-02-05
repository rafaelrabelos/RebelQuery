using System.Data;

namespace RebelQuery.Core
{
    using Models;
    public partial class RQueryResponse<T> : SqlResponse<T>
    {
        /// <summary>
        /// Constructor for RQueryResponse
        /// </summary>
        public RQueryResponse() {
            this.IsSuccessful = false;
            this.DevMessage = "";
            this.UserMessage = "";
            this.StatusCode = "200";
            this.Content = null;
            this.RowsAffected = -2;
        }

        /// <summary>
        /// The given SQL statement.
        /// </summary>
        public string SqlString { get; set; }

        /// <summary>
        /// The raw result obtained by a Sql query
        /// </summary>
       // public DataTable RawResult { get => this.GetRawResult<DataTable>(); set => this.SetRawResult<DataTable>(value); }

    }
}