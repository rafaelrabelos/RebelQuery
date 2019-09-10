using System;
using System.Collections.Generic;

namespace RebelQuery.Models
{
    public class SqlResponse<T>
    {
        private string _devMessage { get; set; }
        private string _userMessage { get; set; }

        public bool IsSuccessful { get; set;}
        public string StatusCode { get; set; }
        public int RowsAffected { get; set; }
        public string DevMessage
        {
            get { return _devMessage; }
            set { _devMessage = value; }
        }
        public string UserMessage
        {
            get { return _userMessage; }
            set { _userMessage = value; }
        }

        public List<T> Content { get; set;}
    }
}
