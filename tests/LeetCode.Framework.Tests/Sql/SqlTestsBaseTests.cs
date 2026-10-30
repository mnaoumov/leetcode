using LeetCode.Sql;

namespace LeetCode.Framework.Tests.Sql;

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

    // Abstract, so NUnit does not run the SQL test it inherits.
    public abstract class FakeSqlTests : SelectSqlTestsBase<FakeSqlTests>;
}
