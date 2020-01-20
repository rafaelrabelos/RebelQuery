using System;
using RebelQuery.Core;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestingRquery
{
    using Mocks;
    using Data;


    public class SelectTests 
    {

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
            foreach ( var item in SelectData.WhereCaseData)
            {
                foreach (var teste in item)
                {
                    SelectData.Character.PassWhereArgs(SelectData.GetConditionArgs(teste) );
                    var dataQuery = SelectData.Character.RQuerySelect<CharacterMock>();

                    Assert.AreEqual(SelectData.GetExpectedResultStatus(teste) , dataQuery.IsSuccessful);
                    Assert.AreEqual(SelectData.GetExpectedItensCount(teste), (dataQuery.Content !=null? dataQuery.Content.Count : 0));
                }
            }

        }
    }
}