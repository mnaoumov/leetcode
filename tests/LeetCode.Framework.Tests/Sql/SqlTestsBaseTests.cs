using LeetCode.Base;
using LeetCode.Framework.Tests;
using LeetCode.Sql;
using NUnit.Framework.Interfaces;

[assembly: ProblemDirectory("LeetCode.Framework.Tests.Sql.SqlProblem", Fixtures.RelativeRoot + "/Sql")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.Sql.SqlUnknownSkipReasonProblem", Fixtures.RelativeRoot + "/SqlUnknownSkipReason")]
[assembly: ProblemDirectory("LeetCode.Framework.Tests.Sql.SqlNoScriptsProblem", Fixtures.RelativeRoot + "/Generic")]

namespace LeetCode.Framework.Tests.Sql
{
    public class SqlTestsBaseTests
    {
        [Test]
        public void DatabaseName_StaysShortForALongProblemName()
        {
            var path = Path.Combine("src", "1384 " + new string('x', 200), "Solution12.sql");
            var name = SqlTestsBase<FakeSqlTests>.GetDatabaseName(path, new SqlTestCase { TestCaseName = "TestCase12" });

            Assert.That(name, Has.Length.LessThanOrEqualTo(128));
            Assert.That(name, Does.Match("^[A-Za-z0-9_]+$"));
        }

        [Test]
        public void DatabaseName_DiffersPerSolutionAndTestCase()
        {
            var names = new[]
            {
                SqlTestsBase<FakeSqlTests>.GetDatabaseName(Path.Combine("0177 Nth", "Solution1.sql"), new SqlTestCase { TestCaseName = "TestCase1" }),
                SqlTestsBase<FakeSqlTests>.GetDatabaseName(Path.Combine("0177 Nth", "Solution1.sql"), new SqlTestCase { TestCaseName = "TestCase2" }),
                SqlTestsBase<FakeSqlTests>.GetDatabaseName(Path.Combine("0177 Nth", "Solution2.sql"), new SqlTestCase { TestCaseName = "TestCase1" })
            };

            Assert.That(names, Is.Unique);
        }

        [Test]
        public void ModifiedTable_IsTheOnlyTable()
        {
            var testCase = CreateTestCase(["id", "email"], ("Person", ["id", "email"]));

            Assert.That(ModifyTableSqlTestsBase<FakeSqlTests>.GetModifiedTable(testCase), Is.EqualTo("Person"));
        }

        [Test]
        public void ModifiedTable_IsTheOneWithTheOutputsColumns()
        {
            var testCase = CreateTestCase(["Id", "Email"], ("Visits", ["id", "date"]), ("Person", ["id", "email"]));

            Assert.That(ModifyTableSqlTestsBase<FakeSqlTests>.GetModifiedTable(testCase), Is.EqualTo("Person"));
        }

        [Test]
        public void ModifiedTable_AmbiguousTablesAreAnError()
        {
            var testCase = CreateTestCase(["id"], ("A", ["id"]), ("B", ["id"]));

            Assert.That(() => ModifyTableSqlTestsBase<FakeSqlTests>.GetModifiedTable(testCase),
                Throws.InvalidOperationException.With.Message.Contains("Cannot tell which table"));
        }

        private static SqlTestCase CreateTestCase(string[] outputHeaders, params (string Table, string[] Columns)[] tables) =>
            new()
            {
                Headers = tables.ToDictionary(table => table.Table, table => table.Columns),
                Rows = tables.ToDictionary(table => table.Table, _ => Array.Empty<object?[]>()),
                Output = new SqlTestCaseOutput { Headers = outputHeaders, Values = [] }
            };

        // Discovery only: a run needs LocalDb.
        [Test]
        public void Discovery_JoinsEveryScriptWithEveryTestCase()
        {
            var cases = SqlTestsBase<SqlProblem.Tests>.JoinedTestCases.ToArray();

            Assert.Multiple(() =>
            {
                Assert.That(cases.Select(c => c.TestName), Is.EquivalentTo(new[] { "Solution1: TestCase1", "Solution2: TestCase1" }));
                Assert.That(cases.Single(c => c.TestName == "Solution1: TestCase1").RunState, Is.EqualTo(RunState.Runnable));
                Assert.That(cases.Single(c => c.TestName == "Solution2: TestCase1").RunState, Is.EqualTo(RunState.Explicit));
            });
        }

        [Test]
        public void Discovery_AnUnknownSkipReasonFailsThatScript()
        {
            var cases = SqlTestsBase<SqlUnknownSkipReasonProblem.Tests>.JoinedTestCases.ToArray();

            Assert.That(cases, Has.Length.EqualTo(1));
            Assert.Multiple(() =>
            {
                Assert.That(cases[0].TestName, Does.StartWith("Solution1: SkipSolution names an unknown reason 'Nope'"));
                Assert.That(cases[0].RunState, Is.EqualTo(RunState.NotRunnable));
            });
        }

        [Test]
        public void Discovery_NoScriptsYieldsOneNotRunnableCase()
        {
            var cases = SqlTestsBase<SqlNoScriptsProblem.Tests>.JoinedTestCases.ToArray();

            Assert.That(cases.Select(c => (c.TestName, c.RunState)),
                Is.EqualTo(new[] { ("No Solution*.sql found", RunState.NotRunnable) }));
        }

        [Test]
        public void Discovery_NoTestCasesYieldsOneNotRunnableCase()
        {
            var cases = SqlTestsBase<FakeSqlTests>.JoinedTestCases.ToArray();

            Assert.That(cases.Select(c => (c.TestName, c.RunState)),
                Is.EqualTo(new[] { ("No test cases found", RunState.NotRunnable) }));
        }

        // Abstract, so NUnit does not run the SQL test it inherits.
        public abstract class FakeSqlTests : SelectSqlTestsBase<FakeSqlTests>;
    }
}

namespace LeetCode.Framework.Tests.Sql.SqlProblem
{
    public abstract class Tests : SelectSqlTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.Sql.SqlUnknownSkipReasonProblem
{
    public abstract class Tests : SelectSqlTestsBase<Tests>;
}

namespace LeetCode.Framework.Tests.Sql.SqlNoScriptsProblem
{
    public abstract class Tests : SelectSqlTestsBase<Tests>;
}
