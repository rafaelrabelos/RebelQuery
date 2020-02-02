using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RebelQuery.Core
{
    using Models;
    using System.Threading.Tasks;

    /// <summary>
    /// RQueryCore provides the engine to run queries
    /// </summary>
    public class RQueryCore : RQueryBuilder
    {
        protected async static  Task<RQueryResponse<T>>  ExecuteQuery<T>(SqlQuery strSQLQuery) where T : new() 
        {

            List<T> entity = new List<T>();
            T obj;
            Type currentRowType;
            object dataRowCurrentValue =null;
            PropertyInfo[] propertys;
            PropertyInfo prop = null;
            SqlDataReader resultDr = null;

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

                SqlConnection conn = new SqlConnection(strSQLQuery.GetConnectionString);
                conn.Open();

                SqlCommand cmd =new SqlCommand(strSQLQuery.QueryString, conn);

                if (cmd != null && (resultDr = await cmd.ExecuteReaderAsync(CommandBehavior.CloseConnection)).HasRows)
                {
                    propertys = new T()
                    .GetType()
                    .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

                    int fieldCount = resultDr.FieldCount
                    ,countProps = propertys.Count()
                    ,a = 0
                    ,b = 0;

                    

                    while (resultDr.Read())
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
                    UserMessage = string.Format("An exception was thrown:\n Property: {0}\n Sql Value: {1}\nSQL Query: {2} ", (prop != null? prop.Name: ""), (dataRowCurrentValue?? "").ToString(), strSQLQuery.QueryString),
                    StatusCode = "200",
                    Content = null,
                    RowsAffected = -1
                };
            }
        }
    }

    

}