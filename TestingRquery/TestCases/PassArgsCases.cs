using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TestingRquery.Data;
using TestingRquery.Mocks;

namespace TestingRquery
{
    public class PassArgsCases : MocksData
    {
        [Test]
        public async Task PassSelectArgsToCharacterSelect()
        {
            CharacterObj.PassSelectArgs(new { name = "", LastName = "" });
            var result = await CharacterObj.RQuerySelectAsync<CharacterMock>();

            Assert.That(result.IsSuccessful, Is.True);
            Assert.That(result.Content.Count, Is.EqualTo(41));
            Assert.That(result.Content.Count(x => x.UserName == null), Is.EqualTo(41));
            Assert.That(result.Content.Count(x => x.Password == null), Is.EqualTo(41));
            Assert.That(result.Content.Count(x => x.Email == null), Is.EqualTo(41));
        }

        [Test]
        public async Task PassSelectArgsToGameSelect()
        {
            GameObj.PassSelectArgs(new { name = "", releaseDate = "" });
            var result = await GameObj.RQuerySelectAsync<GameMock>();

            Assert.That(result.IsSuccessful, Is.True);
            Assert.That(result.Content.Count, Is.EqualTo(11));
            Assert.That(result.Content.Count(x => x.id == 0), Is.EqualTo(11));
            Assert.That(result.Content.Count(x => x.GameCast_Id == null), Is.EqualTo(11));
            Assert.That(result.Content.Count(x => x.Description == null), Is.EqualTo(11));
        }

        [Test]
        public async Task PassWhereArgsToGameSelect()
        {
            GameObj.PassWhereArgs(new { Name = "IN ('NonexistentGame')" });
            var result = await GameObj.RQuerySelectAsync<GameMock>();

            Assert.That(result.IsSuccessful, Is.True);
            Assert.That(result.Content.Count, Is.EqualTo(0));
        }

        [Test]
        public async Task PassWhereArgsToCharacterSelect()
        {
            CharacterObj.PassWhereArgs(new { Name = "='Rebecca'" });
            var result = await CharacterObj.RQuerySelectAsync<CharacterMock>();

            Assert.That(result.IsSuccessful, Is.True);
            Assert.That(result.Content.Count, Is.EqualTo(1));
        }
    }
}
