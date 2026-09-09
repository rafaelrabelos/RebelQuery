using System;
using RebelQuery;

namespace TestingRquery.DAO
{
    public class DAO : RQuery
    {
        public static string TestConnectionString =>
            Environment.GetEnvironmentVariable("REBELQUERY_TEST_CS");

        public static bool HasConnectionString =>
            !string.IsNullOrWhiteSpace(TestConnectionString);

        protected override string ConnectionString => TestConnectionString;
    }
}
