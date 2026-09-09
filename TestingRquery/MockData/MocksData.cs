using NUnit.Framework;
using TestingRquery.DAO;
using TestingRquery.Mocks;

namespace TestingRquery.Data
{
    public abstract class MocksData
    {
        public GameMock GameObj { get; set; }
        public GameCastMock GameCastObj { get; set; }
        public CharacterMock CharacterObj { get; set; }

        protected MocksData()
        {
            GameObj = new GameMock();
            GameCastObj = new GameCastMock();
            CharacterObj = new CharacterMock();
        }

        public static DAO.DAO Query => _query ?? (_query = new DAO.DAO());
        public static CharacterMock Character => _character ?? (_character = new CharacterMock());
        public static GameCastMock GameCast => _gameCast ?? (_gameCast = new GameCastMock());
        public static GameMock Game => _game ?? (_game = new GameMock());

        private static DAO.DAO _query;
        private static CharacterMock _character;
        private static GameCastMock _gameCast;
        private static GameMock _game;

        [OneTimeSetUp]
        public void RequireSqlServer()
        {
            if (!DAO.DAO.HasConnectionString)
                Assert.Ignore("Set REBELQUERY_TEST_CS to run SQL integration tests.");
        }
    }
}
