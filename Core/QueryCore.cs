using System;
using System.Linq;
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

                SqlConnection conn = new SqlConnection(strSQLQuery.ConnectionString);
                conn.Open();

                SqlDataReader resultDr = new SqlCommand(strSQLQuery.QueryString, conn)
                    .ExecuteReader(CommandBehavior.CloseConnection);

                if (resultDr.HasRows)
                {
                    T obj;
                    int fieldCount = resultDr.FieldCount;
                    int propertiesCount = new T().GetType()
                        .GetProperties(
                            BindingFlags.DeclaredOnly |
                            BindingFlags.Public | 
                            BindingFlags.Instance)
                        .Count();

                    while (resultDr.Read())
                    {
                        obj = new T();

                        for (int a =0, b = 0; a < fieldCount && b < propertiesCount; a++)
                        {
                            object value = resultDr.GetValue(a);
                            value = DBNull.Value.Equals(value) ? null: value;

                            PropertyInfo prop = classPropertyInfo
                                .SingleOrDefault(
                                    x =>
                                    x.Name.Equals(resultDr.GetName(a))
                                );

                            if ((prop != null) && prop.CanWrite){
                                prop.SetValue(obj, value);
                                b++;
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