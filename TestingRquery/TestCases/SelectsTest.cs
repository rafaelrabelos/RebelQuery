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

    }
}