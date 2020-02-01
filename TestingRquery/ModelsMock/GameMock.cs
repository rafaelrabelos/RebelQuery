using System;
using RebelQuery;

namespace TestingRquery.Mocks
{
    public class GameMock : DAO.DAO
    {
        [PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? GameCast_Id { get; set; }
        public string Description { get; set; }

    }
}
