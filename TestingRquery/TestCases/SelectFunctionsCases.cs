using System;
using System.Linq;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class SelectFunctionsCases : MocksData
    {

        #region SELECT COUNT
            [Test]
            public void SelectCountAllFromCharacter()
            {
                var actualList = new[]{ 
                        Query.RQueryExecute<int>("SELECT COUNT(*) FROM CharacterMock"),
                        Query.RQueryExecute<int>("SELECT COUNT(id) FROM CharacterMock"),
                        };

                foreach(var actual in actualList){

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(41, actual.Content.Single<int>());
                }
            }
            [Test]
            public void SelectCountAllFromGameCast()
            {
                var actualList = new[]{
                            Query.RQueryExecute<int>("SELECT COUNT(*) FROM GameCastMock"),
                            Query.RQueryExecute<int>("SELECT COUNT(id) FROM GameCastMock"),
                            };

                foreach (var actual in actualList)
                {

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(20, actual.Content.Single<int>());
                }
            }
            [Test]
            public void SelectCountAllFromGame()
            {
                var actualList = new[]{
                            Query.RQueryExecute<int>("SELECT COUNT(*) FROM GameMock"),
                            Query.RQueryExecute<int>("SELECT COUNT(id) FROM GameMock"),
                            };

                foreach (var actual in actualList)
                {

                    Assert.AreEqual(true, actual.IsSuccessful);
                    Assert.AreEqual(-1, actual.RowsAffected);
                    Assert.AreEqual("200", actual.StatusCode);
                    Assert.AreEqual(11, actual.Content.Single<int>());
                }
            }
        #endregion

        #region SELECT GETDATE
        [Test]
        public void SelectGetDate()
        {
            var actualList = new[]{
                        Query.RQueryExecute<DateTime>("SELECT GETDATE()"),
                        };

            foreach (var actual in actualList)
            {

                Assert.AreEqual(true, actual.IsSuccessful);
                Assert.AreEqual(-1, actual.RowsAffected);
                Assert.AreEqual("200", actual.StatusCode);
                Assert.AreEqual(DateTime.Now.Date, actual.Content.Single<DateTime>().Date);
                Assert.AreEqual(DateTime.Now.Minute, actual.Content.Single<DateTime>().Minute);
                Assert.AreEqual(DateTime.Now.Second, actual.Content.Single<DateTime>().Second);
            }
        }
        #endregion


    }
}