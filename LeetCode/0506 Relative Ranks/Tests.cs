using JetBrains.Annotations;

namespace LeetCode._0506_Relative_Ranks;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindRelativeRanks(testCase.Score), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Score { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
