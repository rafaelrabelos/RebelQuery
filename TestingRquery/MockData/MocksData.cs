using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery.Data
{
    using Mocks;

    public class MocksData
    {
        public MocksData()
        {
            GameObj = new GameMock();
            GameCastObj = new GameCastMock();
            CharacterObj = new CharacterMock();
        }

        public GameMock GameObj { get; set; }
        public GameCastMock GameCastObj { get; set; }
        public CharacterMock CharacterObj { get; set; }

        private static CharacterMock _character { get; set; }
        private static GameCastMock _gameCast { get; set; }
        private static GameMock _game { get; set; }
        public static DAO.DAO _query { get; set; }

        public static DAO.DAO Query { 
            get => 
                MocksData._query ??( MocksData._query = new DAO.DAO());
            set => MocksData._query = value;
        }
        public static CharacterMock Character { 
            get => 
                MocksData._character ?? (MocksData._character = new CharacterMock());
            set => MocksData._character = value;
        }
        public static GameCastMock GameCast { 
            get =>
              MocksData._gameCast ?? (MocksData._gameCast = new GameCastMock());
           set => MocksData._gameCast = value;
        }
        public static GameMock Game { 
            get =>
               MocksData._game ?? (MocksData._game = new GameMock());
            set => MocksData._game = value;
        }
        
    }

}