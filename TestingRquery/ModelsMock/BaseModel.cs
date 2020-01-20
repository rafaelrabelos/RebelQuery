using RebelQuery;

namespace TestingRquery.Mocks
{
    public class BaseModel : RQuery
    {
        protected override string ConnectionString { 
            get => @"Data Source=.\SQLEXPRESS;Initial Catalog=teste; Integrated Security=SSPI"; 
            }
    }
}