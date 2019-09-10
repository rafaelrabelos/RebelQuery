
namespace RebelQuery
{
    using Core;

    /// <summary>
    /// IRQueryCore interface implements the core interface
    /// </summary>
    public interface IRQuery
    {
        RQueryResponse<T> RQueryExecute<T>(string quuery, object arg) where T : new();
        RQueryResponse<T> RQueryExecute<T>(DQL command, object arg =null) where T : new();
        RQueryResponse<T> RQueryExecute<T>(DML command, object arg =null) where T : new();
        RQueryResponse<T> RQueryExecute<T>(DDL command, object arg =null) where T : new();
        
        RQueryResponse<T> RQuerySelect<T>(object arg) where T : new();
        RQueryResponse<T> RQueryUpdate<T>(object updateData)where T : new();
        RQueryResponse<T> RQueryInsert<T>(object arg) where T : new();
        RQueryResponse<T> RQueryDelete<T>(object arg) where T : new();
        
        RQuery PassWhereArgs (object args);
        RQuery PassSelectArgs (object args);
    }

}