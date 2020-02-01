using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class SelectsAllCases : MocksData
    {
        #region SELECT * FROM RQueryExecute
            [Test]
            public void QueryExecuteSelectAllFromCharacter()
            {
                var Queries = new List<string>(){
                        "SELECT * FROM CharacterMock",
                        "SELECT id, Name, LastName, UserName, Password, Email, Sex FROM CharacterMock",
                    };

                foreach(var sql in Queries){
                        var actual = Query.RQueryExecute<CharacterMock>(sql);
                        var actual_ = Character.RQueryExecute<CharacterMock>(sql);

                        Assert.AreEqual(actual, actual_);
                        Assert.AreEqual(true, actual.IsSuccessful);
                        Assert.AreEqual(false, actual.Content == null);
                        Assert.AreEqual(true, actual.Content.Count > 0);
                        Assert.AreEqual(true, actual.Content[0].GetType().Equals(typeof(CharacterMock)) );
                    }

            }
            [Test]
            public void QueryExecuteSelectAllFromGame()
            {
                var Queries = new List<string>(){
                        "SELECT * FROM GameMock",
                        "SELECT id, Name, ReleaseDate, GameCast_Id, Description FROM GameMock",
                    };

                foreach(var sql in Queries){
                        var actual = Query.RQueryExecute<GameMock>(sql);
                        var actual_ = Game.RQueryExecute<CharacterMock>(sql);

                        Assert.AreEqual(actual, actual_);
                        Assert.AreEqual(true, actual.IsSuccessful);
                        Assert.AreEqual(false, actual.Content == null);
                        Assert.AreEqual(true, actual.Content.Count > 0);
                        Assert.AreEqual(true, actual.Content[0].GetType().Equals(typeof(GameMock)) );
                    }

            }
            [Test]
            public void QueryExecuteSelectAllFromGameCast()
            {
                var Queries = new List<string>(){
                        "SELECT * FROM GameCastMock",
                        "SELECT id, Character_Id, Game_Id, CharacterIsMajor, Supporting, Playable FROM GameCastMock",
                    };

                foreach(var sql in Queries){
                        var actual = Query.RQueryExecute<GameCastMock>(sql);
                        var actual_ = GameCast.RQueryExecute<CharacterMock>(sql);

                        Assert.AreEqual(actual, actual_);
                        Assert.AreEqual(true, actual.IsSuccessful);
                        Assert.AreEqual(false, actual.Content == null);
                        Assert.AreEqual(true, actual.Content.Count > 0);
                        Assert.AreEqual(true, actual.Content[0].GetType().Equals(typeof(GameCastMock)) );
                    }

            }
            
        #endregion

        #region SELECT * FROM obj.RQuerySelect
            [Test]
            public void Obj_RQuerySelectSelectAllFromCharacter()
            {
                var actualList = new[]{ 
                        Character.RQuerySelect<CharacterMock>(""),
                        Character.RQuerySelect<CharacterMock>(),
                        Character.RQuerySelect<CharacterMock>(null),
                        Character.RQuerySelect<CharacterMock>(new{}),
                        Character.RQuerySelect<CharacterMock>(new CharacterMock()),
                        Character.RQuerySelect<CharacterMock>(new { id="1"
                            
                        })
                        };

                foreach(var actual in actualList){
                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(41, actual.Content.Count);
                }
            }

            [Test]
            public void Obj_RQuerySelectSelectAllFromGame()
            {
                var actualList = new[]{ 
                        Character.RQuerySelect<GameMock>(""),
                        Character.RQuerySelect<GameMock>(),
                        Character.RQuerySelect<GameMock>(null),
                        Character.RQuerySelect<GameMock>(new{})
                        };

                foreach(var actual in actualList){
                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(41, actual.Content.Count);
                }
            }

           [Test]
            public void Obj_RQuerySelectSelectAllFromGameCast()
            {
                var actualList = new[]{ 
                        Character.RQuerySelect<GameCastMock>(""),
                        Character.RQuerySelect<GameCastMock>(),
                        Character.RQuerySelect<GameCastMock>(null),
                        Character.RQuerySelect<GameCastMock>(new{})
                        };

                foreach(var actual in actualList){
                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(41, actual.Content.Count);
                }
            }
        #endregion

    }
}