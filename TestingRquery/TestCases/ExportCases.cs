using System;
using System.Linq;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;
    using System.Text.RegularExpressions;

    public class ConvertCases : MocksData
    {
        public ConvertCases() : base()
        {
        }

        #region PassArgs
            [Test]
            public void CovertGameMockToExcell()
            {
                    var result = CharacterObj.RQuerySelect<CharacterMock>();

                    var xx = result.ToExcell(); 

                    //xx.SaveAs(@"C:\CODE\tste.xlsx");

                    Assert.AreEqual(true, result.IsSuccessful);
                    Assert.AreEqual(41, result.Content.Count);
                    Assert.AreEqual(41, result.Content.Select(x => x.UserName == null).Count() );
                    Assert.AreEqual(41, result.Content.Select(x => x.Password == null).Count());
                    Assert.AreEqual(41, result.Content.Select(x => x.Email == null).Count());
            }
        

        #endregion

    }
}