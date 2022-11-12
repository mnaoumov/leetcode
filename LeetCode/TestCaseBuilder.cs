namespace LeetCode;

public class TestCaseBuilder<TTestCase> where TTestCase : TestCaseBase<TTestCase>
{
    public string TestCaseName { get; init; } = null!;
    public TimeSpan Timeout { get; init; } = TimeSpan.FromMilliseconds(200);
    public Func<TTestCase> TestCaseFunc { get; init; } = null!;
}