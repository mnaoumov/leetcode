using JetBrains.Annotations;

namespace LeetCode._0301_Remove_Invalid_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RemoveInvalidParentheses(testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}