
namespace RebelQuery.Models
{
    public class SqlQuery
    {
        public object SelectArgs {get; set;}
        public object WhereArgs {get; set;}
        public string QueryString {get; set;}
        public string ConnectionString {get; set;}
    }

}