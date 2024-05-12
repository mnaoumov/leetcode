using JetBrains.Annotations;

namespace LeetCode._0039_Combination_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CombinationSum(testCase.Candidates, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Candidates { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
