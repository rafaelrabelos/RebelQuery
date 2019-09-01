
namespace RebelQuery.Core
{

    /// <summary>
    /// IRQueryCore interface implements the core interface
    /// </summary>
    public interface IQueryCore
    {
        
        RQueryResponse<T> RQueryExecute<T>(string quuery, string arg);
        
        RQueryResponse<T> RQuerySelect<T>(string arg) where T : new();
        
        RQueryResponse<T> RQueryUpdate<T>(string arg);
        
        RQueryResponse<T> RQueryInsert<T>(string arg);
        
        RQueryResponse<T> RQueryDelete<T>(string arg);
        
    }

}