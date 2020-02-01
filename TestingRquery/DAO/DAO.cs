using RebelQuery;

namespace TestingRquery.DAO
{
    public class DAO : RQuery
    {
        protected override string ConnectionString { 
            get => @"Data Source=.\SQLEXPRESS;Initial Catalog=teste; Integrated Security=SSPI"; 
            }
    }
}