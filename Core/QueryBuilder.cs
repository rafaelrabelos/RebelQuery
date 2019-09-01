using System;
using System.Reflection;
using System.Text;
using System.Linq;

namespace RebelQuery.Core
{
    using Models;

    /// <summary>
    /// QueryBuilder class 
    /// </summary>
    public class RQueryBuilder
    {
        public object SelectArgs {get; set;}
        public object WhereArgs {get; set;}
        protected SqlQuery BuildAnQuery(DQL command)
        {
            
            SqlQuery query = new SqlQuery
            {
                CommandName = command.ToString(),
                TableName = this.GetType().Name,
            };
            query.QueryString = new StringBuilder("{command} {what} FROM {table} {Where}")
            .Replace("{command}",query.CommandName)
            .Replace("{table}",query.TableName)
            .Replace("{what}", BuildSelectArgs())
            .Replace("{Where}", BuildWhereArgs())
            .ToString();

            return query;
        }

        protected SqlQuery BuildAnQuery(DDL command)
        {
            return new SqlQuery{
                QueryString = command.ToString()
            };
        }

        protected SqlQuery BuildAnQuery(DML command)
        {
            return new SqlQuery{
               QueryString = command.ToString()
            };
        }

        private string  BuildSelectArgs()
        {
            if( this.SelectArgs == null ){
                return "*";
            }
            return  string.Join(
                    ", ", this.SelectArgs
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance |BindingFlags.DeclaredOnly)
                    .Select(x => x.Name)
                    );
                
        }

        private string  BuildWhereArgs()
        {
            if( this.WhereArgs == null ){
                return String.Empty;
            }
            return "WHERE " + string.Join(
                    " ", this.WhereArgs
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance |BindingFlags.DeclaredOnly)
                    .Select(x => x.Name + x.GetValue(this.WhereArgs, null))
                    );
                
        }

    }

}