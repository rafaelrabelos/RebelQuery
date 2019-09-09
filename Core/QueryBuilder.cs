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
    public class RQueryBuilder : SqlQuery
    {
        public object SelectArgs {get; set;}
        public object WhereArgs {get; set;}

        protected SqlQuery BuildAnQuery(string queryStr, object args =null)
        {
            this.QueryString = queryStr;

            return this;
        }
        protected SqlQuery BuildAnQuery(DQL command, object args =null)
        {
            this.QueryString = new StringBuilder("{command} {what} FROM {table} {Where}")
            .Replace("{command}", command.ToString())
            .Replace("{table}", this.GetType().Name)
            .Replace("{what}", BuildSelectArgs())
            .Replace("{Where}", BuildWhereArgs())
            .ToString();

            return this;
        }

        protected SqlQuery BuildAnQuery(DDL command, object args =null)
        {
            return new SqlQuery{
                QueryString = command.ToString()
            };
        }

        protected SqlQuery BuildAnQuery(DML command, object args =null)
        {
            return new SqlQuery{
               QueryString = command.ToString()
            };
        }

        private string  BuildSelectArgs()
        {
            if( this.SelectArgs == null 
            || object.Equals(this.SelectArgs, new{}) 
            || this.SelectArgs.GetType().GetProperties().Count() <= 0 
            ){
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
            if( this.WhereArgs == null 
            || object.Equals(this.SelectArgs, new{}) 
            || this.SelectArgs.GetType().GetProperties().Count() <= 0 
            ){
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