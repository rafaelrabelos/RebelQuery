

namespace RebelQuery
{
    using Core;
    using Models;

    /// <summary>
    /// RQuery execute a query and return a generic data
    /// </summary>
    public class RQuery : RQueryCore, IQueryCore
    {
        public RQuery PassWhereArgs (object args){
            WhereArgs =args;
            return this;
        }
        public RQuery PassSelectArgs (object args){
            SelectArgs =args;
            return this;
        }

        public RQueryResponse<T> RQueryExecute<T>(string quuery, string arg)
        {
            return new RQueryResponse<T>();
        }
        
        public RQueryResponse<T> RQuerySelect<T>(string arg) where T : new()
        {
            return ExecuteQuery<T>(BuildAnQuery(DQL.SELECT));

        }
        
        public RQueryResponse<T> RQueryUpdate<T>(string arg)
        {
            return new RQueryResponse<T>();
        }
        
        public RQueryResponse<T> RQueryInsert<T>(string arg)
        {
            return new RQueryResponse<T>();
        }
        
        public  RQueryResponse<T> RQueryDelete<T>(string arg)
        {
            return new RQueryResponse<T>();
        }
    
        
    }

}