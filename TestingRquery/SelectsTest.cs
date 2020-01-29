using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;


    public class SelectsTests : MocksData
    {
        
    #region SELECT * FROM
        [Test]
        public void SelectAllFromCharacter()
        {
            var actualList = new[]{ 
                    Query.RQueryExecute<CharacterMock>("SELECT * FROM CharacterMock"),
                    Character.RQueryExecute<CharacterMock>("SELECT * FROM CharacterMock"),
                    Character.RQuerySelect<CharacterMock>(""),
                    Character.RQuerySelect<CharacterMock>(),
                    Character.RQuerySelect<CharacterMock>(new{})
                    };

            var expected = new RQueryResponse<GameCastMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200", Content = new List<GameCastMock>(41)
            };

            foreach(var actual in actualList){
                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, expected.Content.Capacity);
            }
        }

        [Test]
        public void SelectAllFromGameCast()
        {
            var actualList = new[]{ 
                Query.RQueryExecute<GameCastMock>("SELECT * FROM GameCastMock"),
                GameCast.RQueryExecute<GameCastMock>("SELECT * FROM GameCastMock"),
                GameCast.RQuerySelect<GameCastMock>(""),
                GameCast.RQuerySelect<GameCastMock>(),
                GameCast.RQuerySelect<GameCastMock>(new{})
                };

            var expected = new RQueryResponse<GameCastMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200", Content = new List<GameCastMock>(20)
            };

            foreach(var actual in actualList){
                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, expected.Content.Capacity);
            }
        }

        [Test]
        public void SelectAllFromGame()
        {
            var actualList = new[]{ 
                Query.RQueryExecute<GameMock>("SELECT * FROM GameMock"),
                Game.RQueryExecute<GameMock>("SELECT * FROM GameMock"),
                Game.RQuerySelect<GameMock>(""),
                Game.RQuerySelect<GameMock>(),
                Game.RQuerySelect<GameMock>(new{})
                };

            var expected = new RQueryResponse<GameMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200", Content = new List<GameMock>(11)
            };

            foreach(var actual in actualList){
                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, expected.Content.Capacity);
            }
        }
    #endregion

    #region SELECT TOP FROM
        
        [Test]
        public void SelectTopXFromCharacter()
        {

            var expected = new RQueryResponse<CharacterMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200"
            };

            for(int x = 1; x < 41; x++){
                var actual = Query.RQueryExecute<CharacterMock>("SELECT TOP "+ x +" * FROM GameMock");

                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, x);
            }
        }

        [Test]
        public void SelectTopXFromGameCast()
        {

            var expected = new RQueryResponse<GameCastMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200"
            };

            for(int x = 1; x < 20; x++){
                var actual = Query.RQueryExecute<GameCastMock>("SELECT TOP "+ x +" * FROM GameMock");

                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, x);
            }
        }

        [Test]
        public void SelectTopXFromGame()
        {

            var expected = new RQueryResponse<GameMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200"
            };

            for(int x = 1; x < 11; x++){
                var actual = Query.RQueryExecute<GameMock>("SELECT TOP "+ x +" * FROM GameMock");

                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, x);
            }
        }
        
    #endregion

    #region SELECT COUNT
        [Test]
        public void SelectCountAllFromGame()
        {
            var actualList = new[]{ 
                    Query.RQueryExecute<GameMock>("SELECT COUNT(*) FROM CharacterMock"),
                    };

            var expected = new RQueryResponse<GameMock>{ 
            IsSuccessful = true, RowsAffected = -1, StatusCode = "200"
            };

            foreach(var actual in actualList){
                Assert.AreEqual(actual.IsSuccessful, expected.IsSuccessful);
                Assert.AreEqual(actual.RowsAffected, expected.RowsAffected);
                Assert.AreEqual(actual.StatusCode, expected.StatusCode);
                Assert.AreEqual(actual.Content.Count, 1);
            }
        }
    #endregion
    

    }
}