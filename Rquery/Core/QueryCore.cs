using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace RebelQuery.Core
{
    using Models;

    /// <summary>
    /// RQueryCore provides the engine to run queries
    /// </summary>
    public class RQueryCore : RQueryBuilder
    {
        protected static async Task<RQueryResponse<T>> ExecuteQuery<T>(SqlQuery strSQLQuery, CancellationToken cancellationToken = default) where T : new()
        {
            List<T> entity = new List<T>();
            T obj;
            Type currentRowType;
            object dataRowCurrentValue = null;
            PropertyInfo[] propertys;
            PropertyInfo prop = null;
            RQueryResponse<T> response = new RQueryResponse<T>();

            try
            {
                if (strSQLQuery.GetConnectionString == null)
                    return new RQueryResponse<T>
                    {
                        IsSuccessful = false,
                        DevMessage = "No conection string given.",
                        UserMessage = "Connection data was not provided.",
                        StatusCode = "200",
                        Content = null,
                        RowsAffected = -1
                    };

                using (var conn = new SqlConnection(strSQLQuery.GetConnectionString))
                using (var cmd = new SqlCommand(strSQLQuery.QueryString, conn))
                {
                    BindParameters(cmd, strSQLQuery);
                    await conn.OpenAsync(cancellationToken).ConfigureAwait(false);

                    using (var resultDr = await cmd.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false))
                    {
                        if (resultDr.HasRows)
                        {
                            propertys = new T()
                            .GetType()
                            .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                            int fieldCount = resultDr.FieldCount
                            ,countProps = propertys.Count()
                            ,a = 0
                            ,b = 0;

                            response.SqlString = strSQLQuery.QueryString;

                            while (await resultDr.ReadAsync(cancellationToken).ConfigureAwait(false))
                            {
                                obj = new T();

                                for (; a < fieldCount && b <= countProps; a++)
                                {
                                    dataRowCurrentValue = resultDr.GetValue(a);
                                    dataRowCurrentValue = DBNull.Value.Equals(dataRowCurrentValue) ? null: dataRowCurrentValue;

                                    prop = propertys.SingleOrDefault( x => x.Name.ToLower().Equals(resultDr.GetName(a).ToLower()) );

                                    if ((prop != null) && prop.CanWrite)
                                    {
                                        if (dataRowCurrentValue != null)
                                            if (prop.PropertyType != (currentRowType = dataRowCurrentValue.GetType()))
                                                if (currentRowType.Equals(typeof(DateTimeOffset)) || currentRowType.Equals(typeof(DateTime)))
                                                    if (prop.PropertyType.Equals(typeof(DateTime)) && DateTime.TryParse(dataRowCurrentValue.ToString(), out DateTime result1))
                                                        dataRowCurrentValue = result1;
                                                    else if (prop.PropertyType.Equals(typeof(DateTimeOffset)) && DateTimeOffset.TryParse(dataRowCurrentValue.ToString(), out DateTimeOffset result2))
                                                        dataRowCurrentValue = result2;
                                                    else
                                                        dataRowCurrentValue = dataRowCurrentValue.ToString();

                                        if (Nullable.GetUnderlyingType(prop.PropertyType) == null)
                                            dataRowCurrentValue = Convert.ChangeType(dataRowCurrentValue, prop.PropertyType);

                                        prop.SetValue(obj, dataRowCurrentValue);
                                        b++;
                                    }
                                    else
                                        obj = (T)resultDr.GetValue(a);
                                }

                                entity.Add(obj);

                                a = b = 0;
                            }
                        }

                        response.SqlString = strSQLQuery.QueryString;
                        response.IsSuccessful = true;
                        response.Content = entity;
                        response.RowsAffected = resultDr.RecordsAffected;

                        return response;
                    }
                }
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception e)
            {
                return new RQueryResponse<T>
                {
                    IsSuccessful = false,
                    DevMessage = e.Message,
                    UserMessage = "An error occurred while executing the query.",
                    Content = null,
                    RowsAffected = -1
                };
            }

        }

        private static void BindParameters(SqlCommand command, SqlQuery query)
        {
            if (query?.Parameters == null)
                return;

            foreach (var parameter in query.Parameters)
            {
                command.Parameters.Add(CreateSqlParameter(parameter));
            }
        }

        private static SqlParameter CreateSqlParameter(SqlQueryParameter parameter)
        {
            var value = parameter.Value ?? DBNull.Value;

            if (value is string text)
            {
                return new SqlParameter(parameter.Name, SqlDbType.NVarChar, text.Length > 4000 ? -1 : 4000)
                {
                    Value = text
                };
            }

            return new SqlParameter(parameter.Name, value);
        }
    }

    

}