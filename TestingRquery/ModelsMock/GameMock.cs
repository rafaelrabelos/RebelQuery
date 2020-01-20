using System;
using RebelQuery;

namespace TestingRquery.Mocks
{
    /*
        CREATE TABLE GameMock (
        id INT IDENTITY(0,1),
        Name VARCHAR(64) NOT NULL,
        ReleaseDate DATE NOT NULL,
        GameCast_Id INT,
        Description TEXT,
        CONSTRAINT PK_GAME PRIMARY KEY(id),
        CONSTRAINT FK_GAME_CAST FOREIGN KEY(GameCast_Id) REFERENCES GameCastMock(id)
        )
    
     */
    public class GameMock : BaseModel
    {
        [PrimaryKey]
        public int id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? GameCast_Id { get; set; }
        public string Description { get; set; }

    }
}
