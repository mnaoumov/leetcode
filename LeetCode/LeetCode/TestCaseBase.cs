namespace LeetCode;

public abstract class TestCaseBase<TTestCase>
{
    public string TestCaseName { get; init; }
    public abstract IEnumerable<TTestCase> TestCases { get; }
}
