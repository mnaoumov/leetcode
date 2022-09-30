namespace LeetCode;

public abstract class TestCaseBuilderBase<TTestCase>
{
    public abstract IEnumerable<(TTestCase testCase, string testCaseName)> TestCasesWithNames { get; }
}