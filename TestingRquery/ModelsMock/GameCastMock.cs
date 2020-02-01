using RebelQuery;

namespace TestingRquery.Mocks
{
    public class GameCastMock : DAO.DAO
    {
        [PrimaryKey]
        public int id { get; set; }
        public int Character_Id { get; set; }
        public int Game_Id { get; set; }
        public bool CharacterIsMajor { get; set; }
        public bool Supporting { get; set; }
        public bool Playable { get; set; }

    }
}