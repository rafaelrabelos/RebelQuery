using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class SelectTopCases : MocksData
    {
        #region SELECT TOP X  * FROM
        
            [Test]
            public void SelectTop_X_AllFromCharacter()
            {
                for(int x = 1; x < 41; x++){

                    var actual = Query.RQueryExecute<CharacterMock>("SELECT TOP "+ x +" * FROM CharacterMock");

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(x, actual.Content.Count);
                }
            }

            [Test]
            public void SelectTop_X_AllFromGameCast()
            {

                for(int x = 1; x < 20; x++){
                    var actual = Query.RQueryExecute<GameCastMock>("SELECT TOP "+ x +" * FROM GameCastMock");

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(x, actual.Content.Count);
                }
            }

            [Test]
            public void SelectTop_X_AllFromGame()
            {

                for(int x = 1; x < 11; x++){
                    var actual = Query.RQueryExecute<GameMock>("SELECT TOP "+ x +" * FROM GameMock");

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(x, actual.Content.Count);
                }
            }
        
        #endregion

    }
}