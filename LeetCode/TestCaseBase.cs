namespace LeetCode;

public abstract class TestCaseBase<TTestCase> where TTestCase : TestCaseBase<TTestCase>
{
    public string? TestCaseName { get; protected init; }
    public abstract IEnumerable<TTestCase> TestCases { get; }
    // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
    public TimeSpan Timeout { get; protected set; } = TimeSpan.FromMilliseconds(200);
}
