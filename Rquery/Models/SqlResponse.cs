using System;
using System.Collections.Generic;

namespace RebelQuery.Models
{
    public class SqlResponse<T>
    {
        private string _devMessage { get; set; }
        private string _userMessage { get; set; }

        /// <summary>
        /// A boolean status of response a query request/execution.
        /// </summary>
        public bool IsSuccessful { get; set;}
        /// <summary>
        /// A related code indicating the actual status of a query request/execution.
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Counts the number of rows affectds by a query request/execution.
        /// </summary>
        public int RowsAffected { get; set; }
        /// <summary>
        /// Related messages to developers level(logs).
        /// </summary>
        public string DevMessage
        {
            get { return _devMessage; }
            set { _devMessage = value; }
        }
        /// <summary>
        /// Related messages to users level.
        /// </summary>
        public string UserMessage
        {
            get { return _userMessage; }
            set { _userMessage = value; }
        }
        /// <summary>
        /// A list of results when a query request/execution are returned. 
        /// </summary>
        public List<T> Content { get; set;}
    }
}
