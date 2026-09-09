using System.Threading;
using System.Threading.Tasks;

namespace RebelQuery
{
    using Core;

    /// <summary>
    /// IRQueryCore interface implements the core interface
    /// </summary>
    public interface IRQuery
    {
        Task<RQueryResponse<T>> RQueryExecuteAsync<T>(string query, object arg = null, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DQL command, object arg = null, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DML command, object arg = null, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DDL command, object arg = null, CancellationToken cancellationToken = default) where T : new();

        Task<RQueryResponse<T>> RQuerySelectAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryUpdateAsync<T>(object updateData, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryInsertAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new();
        Task<RQueryResponse<T>> RQueryDeleteAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new();
        /// <summary>
        /// Sets arguments to be in a SQL`s WHERE clause.
        /// </summary>
        /// <param name="args">A object containig the args : new{TableName="'=clause'"}</param>
        /// <returns>Return a RQuery.</returns>
        RQuery PassWhereArgs (object args);
        /// <summary>
        /// Selects coluns to a SELECT clause.
        /// </summary>
        /// <param name="args">A object containig the args : new{ColunA_Name, ColunB_Name, ...,ColunN_Name}</param>
        /// <returns>Return a RQuery.</returns>
        RQuery PassSelectArgs (object args);
    }

}
