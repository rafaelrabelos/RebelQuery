using System;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RebelQuery.Core
{
    using Models;

    /// <summary>
    /// RQueryCore provides the engine to run queries
    /// </summary>
    public class RQueryCore : RQueryBuilder
    {
        protected static RQueryResponse<T> ExecuteQuery<T>(SqlQuery strSQLQuery) where T : new()
        {
            try
            {
                List<T> entity = new List<T>();
                PropertyInfo[] classPropertyInfo = typeof(T).GetProperties();

                if (strSQLQuery.ConnectionString == null)
                    return new RQueryResponse<T>
                    {
                        IsSuccessful = false,
                        DevMessage = "No conection string given.",
                        UserMessage = "Connection data was not provided.",
                        StatusCode = "200",
                        Content = null,
                        RowsAffected = -1
                    };

                var conn = new SqlConnection(strSQLQuery.ConnectionString);
                conn.Open();
                var resultDr = new SqlCommand(strSQLQuery.QueryString, conn).ExecuteReader(CommandBehavior.CloseConnection);

                if (resultDr.HasRows)
                {
                    while (resultDr.Read())
                    {
                        T obj = new T();

                        foreach (var p in classPropertyInfo)
                        {
                            if ((p != null) && p.CanWrite)
                            {
                                p.SetValue(obj, resultDr.GetValue(resultDr.GetOrdinal(p.Name)), null);
                            }
                        }

                        entity.Add(obj);
                    }

                    resultDr.Close();
                }

                return new RQueryResponse<T>
                {
                    IsSuccessful = true,
                    DevMessage = "",
                    UserMessage = "",
                    StatusCode = "200",
                    Content = entity,
                    RowsAffected = resultDr.RecordsAffected
                };

            }
            catch (Exception e)
            {
                return new RQueryResponse<T>
                {
                    IsSuccessful = false,
                    DevMessage = e.Message,
                    UserMessage = "An exception was thrown",
                    StatusCode = "200",
                    Content = null,
                    RowsAffected = -1
                };
            }
        }
    }

}