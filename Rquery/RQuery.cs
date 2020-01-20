

namespace RebelQuery
{
    using Core;

    /// <summary>
    /// RQuery deliveries interface access to the core engine of query execution.
    /// </summary>
    public abstract class RQuery : RQueryCore, IRQuery
    {
        protected abstract override string ConnectionString { get; }
        public RQueryResponse<T> RQueryExecute<T>(string query, object arg =null) where T : new() =>
         ExecuteQuery<T>(BuildAnQuery(query, arg));
        
        public RQueryResponse<T> RQueryExecute<T>(DQL command, object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery(command, arg));
        public RQueryResponse<T> RQueryExecute<T>(DML command, object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery<T>(command, arg));

        public RQueryResponse<T> RQueryExecute<T>(DDL command, object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery(command, arg));
        
        public RQueryResponse<T> RQuerySelect<T>(object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery(DQL.SELECT, arg));
        
        public RQueryResponse<T> RQueryUpdate<T>(object updateData ) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery<T>(DML.UPDATE, updateData));
        
        public RQueryResponse<T> RQueryInsert<T>(object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery<T>(DML.INSERT, arg));
        
        public  RQueryResponse<T> RQueryDelete<T>(object arg =null) where T : new() =>
        ExecuteQuery<T>(BuildAnQuery<T>(DML.DELETE, arg));

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