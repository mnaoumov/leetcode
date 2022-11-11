namespace LeetCode;

public abstract class TestCaseBase<TTestCase> where TTestCase : TestCaseBase<TTestCase>
{
    public string? TestCaseName { get; protected init; }
    public abstract IEnumerable<TTestCase> TestCases { get; }
    public TimeSpan Timeout { get; protected init; } = TimeSpan.FromMilliseconds(200);
}
