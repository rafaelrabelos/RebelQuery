using System.Threading.Tasks;
using NUnit.Framework;
using TestingRquery.Data;

namespace TestingRquery
{
    public class MappingTypesCases : MocksData
    {
        [TestCase("SELECT ReleaseDate AS TypeDateTime FROM GameMock")]
        [TestCase("SELECT ReleaseDate AS TypeDateTimeOffset FROM GameMock")]
        [TestCase("SELECT Sex AS TypeChar FROM CharacterMock")]
        [TestCase("SELECT id AS TypeString FROM GameMock")]
        [TestCase("SELECT name AS TypeString FROM GameMock")]
        [TestCase("SELECT ReleaseDate AS TypeString FROM GameMock")]
        [TestCase("SELECT Description AS TypeString FROM GameMock")]
        [TestCase("SELECT Playable AS TypeString FROM GameCastMock")]
        [TestCase("SELECT Sex AS TypeString FROM CharacterMock")]
        [TestCase("SELECT id AS TypeSbyte FROM CharacterMock")]
        [TestCase("SELECT id AS TypeByte FROM CharacterMock")]
        [TestCase("SELECT id AS TypeShort FROM CharacterMock")]
        [TestCase("SELECT id AS TypeUshort FROM CharacterMock")]
        [TestCase("SELECT id AS TypeInt FROM CharacterMock")]
        [TestCase("SELECT id AS TypeUint FROM CharacterMock")]
        [TestCase("SELECT id AS TypeLong FROM CharacterMock")]
        [TestCase("SELECT id AS TypeUlong FROM CharacterMock")]
        [TestCase("SELECT id AS TypeFloat FROM CharacterMock")]
        [TestCase("SELECT id AS TypeDouble FROM CharacterMock")]
        [TestCase("SELECT id AS TypeDecimal FROM CharacterMock")]
        public async Task MapsAliasedColumn(string sql)
        {
            var actual = await Query.RQueryExecuteAsync<TypeData>(sql);

            Assert.That(actual.IsSuccessful, Is.True);
            Assert.That(actual.Content, Is.Not.Null);
            Assert.That(actual.Content.Count, Is.GreaterThan(0));
        }
    }
}
