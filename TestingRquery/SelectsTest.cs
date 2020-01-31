using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class ApplicationTests : MocksData
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
                    var actual = Query.RQueryExecute<CharacterMock>("SELECT TOP "+ x +" * FROM CharacterMock(NOLOCK)");

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
                    var actual = Query.RQueryExecute<GameCastMock>("SELECT TOP "+ x +" * FROM GameCastMock");

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


        #region PassArgs
            [Test]
            public void PassSelectArgsTest()
            {

                foreach (var item in SelectData.SelectCaseData)
                {
                    SelectData.Character = null;
                    foreach (var teste in item)
                    {
                        SelectData.Character.PassSelectArgs(SelectData.GetConditionArgs(teste));
                        var dataQuery = SelectData.Character.RQuerySelect<CharacterMock>();

                        Assert.AreEqual(SelectData.GetExpectedResultStatus(teste), dataQuery.IsSuccessful);
                        Assert.AreEqual(SelectData.GetExpectedItensCount(teste), (dataQuery.Content != null ? dataQuery.Content.Count : 0));
                    }
                }

            }

            [Test]
            public void PassWhereArgsTest()
            {
                SelectData.Character = null;
                foreach (var item in SelectData.WhereCaseData)
                {
                    foreach (var teste in item)
                    {
                        SelectData.Character.PassWhereArgs(SelectData.GetConditionArgs(teste));
                        var dataQuery = SelectData.Character.RQuerySelect<CharacterMock>();

                        Assert.AreEqual(SelectData.GetExpectedResultStatus(teste), dataQuery.IsSuccessful);
                        Assert.AreEqual(SelectData.GetExpectedItensCount(teste), (dataQuery.Content != null ? dataQuery.Content.Count : 0));
                    }
                }

            }

        #endregion


        #region Mapping Types

        [Test]
        public void TypeSbyteMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeSbyte FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeSbyte FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }

        }

        [Test]
        public void TypeByteMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeByte FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeByte FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }

        [Test]
        public void TypeShortMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeShort FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeShort FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeUshortMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeUshort FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeUshort FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeIntMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeInt FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeInt FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeUintMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeUint FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeUint FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeLongMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeLong FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeLong FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeUlongMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeUlong FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeUlong FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeFloatMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeFloat FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeFloat FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeDoubleMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeDouble FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeDouble FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeDecimalMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeDecimal FROM CharacterMock",
                "SELECT CharacterIsMajor AS TypeDecimal FROM GameCastMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        
        [Test]
        public void TypeCharMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT Sex AS TypeChar FROM CharacterMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }

        [Test]
        public void TypeStringMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT id AS TypeString FROM GameMock",
                "SELECT name AS TypeString FROM GameMock",
                "SELECT ReleaseDate AS TypeString FROM GameMock",
                "SELECT Description AS TypeString FROM GameMock",
                "SELECT Playable AS TypeString FROM GameCastMock",
                "SELECT Sex AS TypeString FROM CharacterMock"
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
            
        }
        
        [Test]
        public void TypeDateTimeMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT ReleaseDate AS TypeDateTime FROM GameMock",
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }
        [Test]
        public void TypeDateTimeOffsetMappingTest()
        {
            var Queries = new List<string>(){
                "SELECT ReleaseDate AS TypeDateTimeOffset FROM GameMock",
            };

            foreach(var sql in Queries){
                var actual = Query.RQueryExecute<TypeData>(sql);
                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(false, actual.Content == null);
                Assert.AreEqual(true, actual.Content.Count > 0);
            }
        }

        #endregion

    }
}