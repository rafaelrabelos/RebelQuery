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

                    foreach (var item in new List<RQueryResponse<CharacterMock>> { actual, actual_ })
                    {
                        Assert.AreEqual(true, item.IsSuccessful);
                        Assert.AreEqual(false, item.Content == null);
                        Assert.AreEqual(true, item.Content.Count > 0);
                        Assert.AreEqual(true, item.Content[0].GetType().Equals(typeof(CharacterMock)));
                    }
                        
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
                        var actual_ = Game.RQueryExecute<GameMock>(sql);

                    foreach (var item in new List<RQueryResponse<GameMock>> { actual, actual_ })
                    {
                        Assert.AreEqual(true, item.IsSuccessful);
                        Assert.AreEqual(false, item.Content == null);
                        Assert.AreEqual(true, item.Content.Count > 0);
                        Assert.AreEqual(true, item.Content[0].GetType().Equals(typeof(GameMock)));
                    }
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
                        var actual_ = GameCast.RQueryExecute<GameCastMock>(sql);

                    foreach (var item in new List<RQueryResponse<GameCastMock>> { actual, actual_ })
                    {
                        Assert.AreEqual(true, item.IsSuccessful);
                        Assert.AreEqual(false, item.Content == null);
                        Assert.AreEqual(true, item.Content.Count > 0);
                        Assert.AreEqual(true, item.Content[0].GetType().Equals(typeof(GameCastMock)));
                    }
            }

            }
            
        #endregion

        #region SELECT * FROM Obj.RQuerySelect
            [Test]
            public void Obj_RQuerySelectSelectAllFromCharacter()
            {
                var actualList = new[]{ 
                        Character.RQuerySelect<CharacterMock>(""),
                        Character.RQuerySelect<CharacterMock>(),
                        Character.RQuerySelect<CharacterMock>(null),
                        Character.RQuerySelect<CharacterMock>(new{})
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
                        Game.RQuerySelect<GameMock>(""),
                        Game.RQuerySelect<GameMock>(),
                        Game.RQuerySelect<GameMock>(null),
                        Game.RQuerySelect<GameMock>(new{})
                        };

                foreach(var actual in actualList){
                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(11, actual.Content.Count);
                }
            }

           [Test]
            public void Obj_RQuerySelectSelectAllFromGameCast()
            {
                var actualList = new[]{
                        GameCast.RQuerySelect<GameCastMock>(""),
                        GameCast.RQuerySelect<GameCastMock>(),
                        GameCast.RQuerySelect<GameCastMock>(null),
                        GameCast.RQuerySelect<GameCastMock>(new{})
                        };

                foreach(var actual in actualList){
                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(20, actual.Content.Count);
                }
            }
        #endregion

    }
}