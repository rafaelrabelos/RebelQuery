using System;
using System.Linq;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class PassArgsCases : MocksData
    {
        public PassArgsCases() : base()
        {
        }

        #region PassArgs
            [Test]
            public void PassSelectArgsToCharacterSelect()
            {
                    CharacterObj.PassSelectArgs(new { name = "", LastName = "" });
                    var result = CharacterObj.RQuerySelect<CharacterMock>();

                    Assert.AreEqual(true, result.IsSuccessful);
                    Assert.AreEqual(41, result.Content.Count);
                    Assert.AreEqual(41, result.Content.Select(x => x.UserName == null).Count() );
                    Assert.AreEqual(41, result.Content.Select(x => x.Password == null).Count());
                    Assert.AreEqual(41, result.Content.Select(x => x.Email == null).Count());

            }
            [Test]
            public void PassSelectArgsToGameSelect()
            {
                GameObj.PassSelectArgs(new { name = "", releaseDate = "" });
                var result = GameObj.RQuerySelect<GameMock>();

                Assert.AreEqual(true, result.IsSuccessful);
                Assert.AreEqual(11, result.Content.Count);
                Assert.AreEqual(11, result.Content.Select(x => x.id == 0).Count());
                Assert.AreEqual(11, result.Content.Select(x => x.GameCast_Id == null).Count());
                Assert.AreEqual(11, result.Content.Select(x => x.Description == null).Count());

            }
            [Test]
            public void PassWhereArgsToGameSelect()
            {
                GameObj.PassWhereArgs(new { Name = "IN('Rebecca', 'Billy)'" });
                var result = GameObj.RQuerySelect<GameMock>();

                Assert.AreEqual(false, result.IsSuccessful);

            }
            [Test]
            public void PassWhereArgsToCharacterSelect()
            {
                CharacterObj.PassWhereArgs(new { Name = "='Rebecca'" });
                var result = CharacterObj.RQuerySelect<CharacterMock>();

                Assert.AreEqual(true, result.IsSuccessful);
                Assert.AreEqual(1, result.Content.Count);

            }
        

        #endregion

    }
}