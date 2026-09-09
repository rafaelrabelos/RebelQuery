using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using RebelQuery.Core;
using TestingRquery.Support;

namespace TestingRquery
{
    public class ExecuteEngineCases
    {
        [Test]
        public async Task MissingConnectionStringReturnsFailedResponse()
        {
            var probe = new ClientProbe { Connection = null };
            var result = await probe.RQueryExecuteAsync<ClientProbe>("SELECT 1");

            Assert.That(result.IsSuccessful, Is.False);
            Assert.That(result.Content, Is.Null);
            Assert.That(result.DevMessage, Does.Contain("conection").IgnoreCase);
        }

        [Test]
        public void CanceledTokenThrows()
        {
            var probe = new ClientProbe { Connection = "Server=127.0.0.1,1;Database=x;User Id=x;Password=x;Connection Timeout=1;" };
            using var cts = new CancellationTokenSource();
            cts.Cancel();

            Assert.CatchAsync<OperationCanceledException>(() =>
                probe.RQueryExecuteAsync<ClientProbe>("SELECT 1", null, cts.Token));
        }

        [Test]
        public void ToExcellWritesRows()
        {
            var response = new RQueryResponse<ClientProbe>
            {
                IsSuccessful = true,
                Content = new List<ClientProbe>
                {
                    new ClientProbe { Id = 1, Name = "Ada", Email = "ada@example.com" }
                }
            };

            using var workbook = response.ToExcell();
            var sheet = workbook.Worksheets.First();

            Assert.That(sheet.Name, Is.EqualTo(nameof(ClientProbe)));
            var headers = Enumerable.Range(1, 8)
                .Select(col => sheet.Cell(1, col).GetString())
                .Where(value => !string.IsNullOrEmpty(value))
                .ToArray();
            Assert.That(headers, Does.Contain("Name"));
            Assert.That(headers, Does.Contain("Email"));
        }

        [Test]
        public void ToExcellAllowsEmptyOrNullContent()
        {
            var empty = new RQueryResponse<ClientProbe>
            {
                IsSuccessful = true,
                Content = new List<ClientProbe>()
            };
            var missing = new RQueryResponse<ClientProbe>
            {
                IsSuccessful = true,
                Content = null
            };

            Assert.DoesNotThrow(() => empty.ToExcell().Dispose());
            Assert.DoesNotThrow(() => missing.ToExcell().Dispose());
        }
    }
}
