using RebelQuery;

namespace TestingRquery.Mocks
{
    /*
        CREATE TABLE GameCastMock (
        id INT IDENTITY(0,1),
        Character_Id INT NOT NULL,
        Game_Id INT NOT NULL,
        CharacterIsMajor BIT NOT NULL DEFAULT 0,
        Supporting BIT NOT NULL DEFAULT 0,
        Playable BIT NOT NULL DEFAULT 0,
        CONSTRAINT PK_CAST PRIMARY KEY(id),
        CONSTRAINT FK_CHARACTER FOREIGN KEY(Character_Id) REFERENCES CharacterMock(id),
        CONSTRAINT FK_GAMECAST_GAME FOREIGN KEY(Game_Id) REFERENCES GameMock(id)
        )
     */
    public class GameCastMock : BaseModel
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