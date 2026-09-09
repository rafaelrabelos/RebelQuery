using RebelQuery;
using RebelQuery.Models;

namespace TestingRquery.Support
{
    public class ClientProbe : RQuery
    {
        protected override string ConnectionString => Connection;

        public string Connection { get; set; }

        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public SqlQuery BuildExplicit(string sql, object args = null) => BuildAnQuery(sql, args);

        public SqlQuery BuildSelect() => BuildAnQuery(DQL.SELECT, null);

        public SqlQuery BuildUpdate(object data) => BuildAnQuery<ClientProbe>(DML.UPDATE, data);
    }
}
