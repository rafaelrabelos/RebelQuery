using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class MappingTypesCases : MocksData
    {

        #region Mapping Dates
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

        #region Mapping character chain
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
        
        #endregion

        #region Mapping Number

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
            
        #endregion

    }
}