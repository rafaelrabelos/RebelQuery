using RebelQuery;

namespace TestingRquery.Mocks
{

    public class CharacterMock : DAO.DAO
    {
        [PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }

    }
}