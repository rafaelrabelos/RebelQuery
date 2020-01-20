using RebelQuery;

namespace TestingRquery.Mocks
{
    /*
        CREATE TABLE CharacterMock (
        id INT IDENTITY(0,1),
        Name VARCHAR(64) NOT NULL,
        LastName VARCHAR(64) NOT NULL,
        UserName VARCHAR(32) NOT NULL UNIQUE,
        Password VARCHAR(16) NOT NULL,
        Email VARCHAR(32) NOT NULL,
        Sex CHAR(1) NOT NULL,
        CONSTRAINT PK_CHARACTER PRIMARY KEY(id)
        )
     */
    public class CharacterMock : BaseModel
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