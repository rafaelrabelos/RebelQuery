using System;
using System.Linq;
using NUnit.Framework;
using TestingRquery.Support;

namespace TestingRquery
{
    public class QueryBuilderCases
    {
        [Test]
        public void ExplicitQueryKeepsPlaceholdersAndBindsValues()
        {
            var probe = new ClientProbe();
            var query = probe.BuildExplicit(
                "SELECT * FROM ClientProbe WHERE Id = @id AND Name = @name",
                new { id = 6, name = "Ada" });

            Assert.That(query.QueryString, Does.Contain("@id"));
            Assert.That(query.QueryString, Does.Not.Contain("'Ada'"));
            Assert.That(query.Parameters.Any(p => p.Name == "@id" && Equals(p.Value, 6)), Is.True);
            Assert.That(query.Parameters.Any(p => p.Name == "@name" && Equals(p.Value, "Ada")), Is.True);
        }

        [Test]
        public void WhereArgsUsesParametersAndAnd()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Id = "=6", Name = "='Ada'" });
            var query = probe.BuildSelect();

            Assert.That(query.QueryString, Does.Contain("WHERE Id = @rq_where_Id AND Name = @rq_where_Name"));
            Assert.That(query.Parameters.Single(p => p.Name == "@rq_where_Id").Value, Is.EqualTo(6));
            Assert.That(query.Parameters.Single(p => p.Name == "@rq_where_Name").Value, Is.EqualTo("Ada"));
        }

        [Test]
        public void WhereInjectionStaysInsideParameter()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Id = "=1 OR 1=1" });
            var query = probe.BuildSelect();

            Assert.That(query.QueryString, Does.Not.Contain("OR 1=1"));
            Assert.That(query.QueryString, Does.Contain("Id = @rq_where_Id"));
            Assert.That(query.Parameters.Single().Value, Is.EqualTo("1 OR 1=1"));
        }

        [Test]
        public void WhereInBuildsOneParameterPerValue()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Name = "IN ('Ada', 'Grace')" });
            var query = probe.BuildSelect();

            Assert.That(query.QueryString, Does.Contain("Name IN (@rq_where_Name_0, @rq_where_Name_1)"));
            Assert.That(query.Parameters.Select(p => p.Value), Is.EquivalentTo(new object[] { "Ada", "Grace" }));
        }

        [Test]
        public void WhereIsNullHasNoParameter()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Email = "IS NULL" });
            var query = probe.BuildSelect();

            Assert.That(query.QueryString, Does.Contain("Email IS NULL"));
            Assert.That(query.Parameters, Is.Empty);
        }

        [Test]
        public void UpdateSetSkipsPrimaryKeyAndParameterizesValues()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Id = 6 });
            var query = probe.BuildUpdate(new { Id = 6, Name = "Ada", Email = "ada@example.com" });

            Assert.That(query.QueryString, Does.StartWith("UPDATE ClientProbe SET "));
            Assert.That(query.QueryString, Does.Not.Contain("Id=@rq_set_Id"));
            Assert.That(query.QueryString, Does.Contain("Name=@rq_set_Name"));
            Assert.That(query.QueryString, Does.Contain("Email=@rq_set_Email"));
            Assert.That(query.Parameters.Any(p => p.Name == "@rq_set_Name" && Equals(p.Value, "Ada")), Is.True);
        }

        [Test]
        public void SelectArgsListsOnlyRequestedColumns()
        {
            var probe = new ClientProbe();
            probe.PassSelectArgs(new { probe.Name, probe.Email });
            var query = probe.BuildSelect();

            Assert.That(query.QueryString, Is.EqualTo("SELECT Name, Email FROM ClientProbe "));
        }

        [Test]
        public void EmptyInListIsRejected()
        {
            var probe = new ClientProbe();
            probe.PassWhereArgs(new { Id = "IN ()" });

            Assert.Throws<ArgumentException>(() => probe.BuildSelect());
        }
    }
}
