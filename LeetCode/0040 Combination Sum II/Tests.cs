using JetBrains.Annotations;

namespace LeetCode._0040_Combination_Sum_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.CombinationSum2(testCase.Candidates, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Candidates { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}