
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