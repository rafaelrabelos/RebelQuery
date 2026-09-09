using System.Threading.Tasks;
using NUnit.Framework;
using TestingRquery.Data;
using TestingRquery.Mocks;

namespace TestingRquery
{
    public class SelectTopCases : MocksData
    {
        [Test]
        public async Task SelectTop_X_AllFromCharacter()
        {
            for (var x = 1; x < 41; x++)
            {
                var actual = await Query.RQueryExecuteAsync<CharacterMock>("SELECT TOP (@n) * FROM CharacterMock", new { n = x });

                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(x));
            }
        }

        [Test]
        public async Task SelectTop_X_AllFromGameCast()
        {
            for (var x = 1; x < 20; x++)
            {
                var actual = await Query.RQueryExecuteAsync<GameCastMock>("SELECT TOP (@n) * FROM GameCastMock", new { n = x });

                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(x));
            }
        }

        [Test]
        public async Task SelectTop_X_AllFromGame()
        {
            for (var x = 1; x < 11; x++)
            {
                var actual = await Query.RQueryExecuteAsync<GameMock>("SELECT TOP (@n) * FROM GameMock", new { n = x });

                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(x));
            }
        }
    }
}
