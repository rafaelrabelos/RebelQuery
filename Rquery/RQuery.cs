using System.Threading;
using System.Threading.Tasks;

namespace RebelQuery
{
    using Core;

    /// <summary>
    /// RQuery deliveries interface access to the core engine of query execution.
    /// </summary>
    public abstract class RQuery : RQueryCore, IRQuery
    {

        protected abstract override string ConnectionString { get; }

        public Task<RQueryResponse<T>> RQueryExecuteAsync<T>(string query, object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery(query, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DQL command, object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery(command, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DML command, object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery<T>(command, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQueryExecuteAsync<T>(DDL command, object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery(command, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQuerySelectAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery(DQL.SELECT, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQueryUpdateAsync<T>(object updateData, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery<T>(DML.UPDATE, updateData), cancellationToken);

        public Task<RQueryResponse<T>> RQueryInsertAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery<T>(DML.INSERT, arg), cancellationToken);

        public Task<RQueryResponse<T>> RQueryDeleteAsync<T>(object arg = null, CancellationToken cancellationToken = default) where T : new() =>
            ExecuteQuery<T>(BuildAnQuery<T>(DML.DELETE, arg), cancellationToken);

        public RQuery PassWhereArgs (object args=null){
            WhereArgs =args;
            return this;
        }

        public RQuery PassSelectArgs (object args=null){
            SelectArgs =args;
            return this;
        }

    }

}
