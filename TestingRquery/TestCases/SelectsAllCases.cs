using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using RebelQuery.Core;
using TestingRquery.Data;
using TestingRquery.Mocks;

namespace TestingRquery
{
    public class SelectsAllCases : MocksData
    {
        [Test]
        public async Task QueryExecuteSelectAllFromCharacter()
        {
            var queries = new[]
            {
                "SELECT * FROM CharacterMock",
                "SELECT id, Name, LastName, UserName, Password, Email, Sex FROM CharacterMock",
            };

            foreach (var sql in queries)
            {
                var fromDao = await Query.RQueryExecuteAsync<CharacterMock>(sql);
                var fromEntity = await Character.RQueryExecuteAsync<CharacterMock>(sql);

                foreach (var item in new List<RQueryResponse<CharacterMock>> { fromDao, fromEntity })
                {
                    Assert.That(item.IsSuccessful, Is.True);
                    Assert.That(item.Content, Is.Not.Null);
                    Assert.That(item.Content.Count, Is.GreaterThan(0));
                    Assert.That(item.Content[0], Is.TypeOf<CharacterMock>());
                }
            }
        }

        [Test]
        public async Task QueryExecuteSelectAllFromGame()
        {
            var queries = new[]
            {
                "SELECT * FROM GameMock",
                "SELECT id, Name, ReleaseDate, GameCast_Id, Description FROM GameMock",
            };

            foreach (var sql in queries)
            {
                var fromDao = await Query.RQueryExecuteAsync<GameMock>(sql);
                var fromEntity = await Game.RQueryExecuteAsync<GameMock>(sql);

                foreach (var item in new List<RQueryResponse<GameMock>> { fromDao, fromEntity })
                {
                    Assert.That(item.IsSuccessful, Is.True);
                    Assert.That(item.Content, Is.Not.Null);
                    Assert.That(item.Content.Count, Is.GreaterThan(0));
                    Assert.That(item.Content[0], Is.TypeOf<GameMock>());
                }
            }
        }

        [Test]
        public async Task QueryExecuteSelectAllFromGameCast()
        {
            var queries = new[]
            {
                "SELECT * FROM GameCastMock",
                "SELECT id, Character_Id, Game_Id, CharacterIsMajor, Supporting, Playable FROM GameCastMock",
            };

            foreach (var sql in queries)
            {
                var fromDao = await Query.RQueryExecuteAsync<GameCastMock>(sql);
                var fromEntity = await GameCast.RQueryExecuteAsync<GameCastMock>(sql);

                foreach (var item in new List<RQueryResponse<GameCastMock>> { fromDao, fromEntity })
                {
                    Assert.That(item.IsSuccessful, Is.True);
                    Assert.That(item.Content, Is.Not.Null);
                    Assert.That(item.Content.Count, Is.GreaterThan(0));
                    Assert.That(item.Content[0], Is.TypeOf<GameCastMock>());
                }
            }
        }

        [Test]
        public async Task Obj_RQuerySelectSelectAllFromCharacter()
        {
            var actualList = new[]
            {
                await Character.RQuerySelectAsync<CharacterMock>(""),
                await Character.RQuerySelectAsync<CharacterMock>(),
                await Character.RQuerySelectAsync<CharacterMock>(null),
                await Character.RQuerySelectAsync<CharacterMock>(new { })
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(41));
            }
        }

        [Test]
        public async Task Obj_RQuerySelectSelectAllFromGame()
        {
            var actualList = new[]
            {
                await Game.RQuerySelectAsync<GameMock>(""),
                await Game.RQuerySelectAsync<GameMock>(),
                await Game.RQuerySelectAsync<GameMock>(null),
                await Game.RQuerySelectAsync<GameMock>(new { })
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(11));
            }
        }

        [Test]
        public async Task Obj_RQuerySelectSelectAllFromGameCast()
        {
            var actualList = new[]
            {
                await GameCast.RQuerySelectAsync<GameCastMock>(""),
                await GameCast.RQuerySelectAsync<GameCastMock>(),
                await GameCast.RQuerySelectAsync<GameCastMock>(null),
                await GameCast.RQuerySelectAsync<GameCastMock>(new { })
            };

            foreach (var actual in actualList)
            {
                Assert.That(actual.IsSuccessful, Is.True);
                Assert.That(actual.Content.Count, Is.EqualTo(20));
            }
        }
    }
}
