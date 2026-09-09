using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingRquery.Data;

namespace TestingRquery
{
    public class SelectFunctionsCases : MocksData
    {
        [Test]
        public async Task SelectCountAllFromCharacter()
        {
            var actualList = new[]
            {
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(*) FROM CharacterMock"),
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(id) FROM CharacterMock"),
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Single(), Is.EqualTo(41));
            }
        }

        [Test]
        public async Task SelectCountAllFromGameCast()
        {
            var actualList = new[]
            {
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(*) FROM GameCastMock"),
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(id) FROM GameCastMock"),
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Single(), Is.EqualTo(20));
            }
        }

        [Test]
        public async Task SelectCountAllFromGame()
        {
            var actualList = new[]
            {
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(*) FROM GameMock"),
                await Query.RQueryExecuteAsync<int>("SELECT COUNT(id) FROM GameMock"),
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Single(), Is.EqualTo(11));
            }
        }

        [Test]
        public async Task SelectGetDate()
        {
            var actual = await Query.RQueryExecuteAsync<DateTime>("SELECT GETDATE()");

            Assert.That(actual.IsSuccessful, Is.True);
            Assert.That(actual.Content.Single().Date, Is.EqualTo(DateTime.Now.Date));
        }
    }
}
