namespace LeetCode;

public abstract class TestCaseBase<TTestCase> where TTestCase : TestCaseBase<TTestCase>
{
    public string? TestCaseName { get; protected init; }
    public virtual IEnumerable<TTestCase> TestCases
    {
        get { yield break; }
    }

    public virtual IEnumerable<TestCaseBuilder<TTestCase>> TestCaseBuilders
    {
        get
        {
            return TestCases.Select(testCase => new TestCaseBuilder<TTestCase>
            {
                TestCaseName = testCase.TestCaseName,
                Timeout = testCase.Timeout,
                TestCaseFunc = () => testCase
            });
        }
    }

    public TimeSpan Timeout { get; protected init; } = TimeSpan.FromMilliseconds(200);
}