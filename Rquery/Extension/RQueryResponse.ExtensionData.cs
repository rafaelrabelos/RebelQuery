using System;
using System.IO;
using System.Data;

namespace RebelQuery.Core
{
    using Interfaces;
    

    public partial class RQueryResponse<T>
    {
        private dynamic _raw { get; set; }

        private T1 GetRawResult<T1>() => (T1)_raw;
        private void SetRawResult<T1>(T1 value) { _raw = (T1)value; }
    }

}