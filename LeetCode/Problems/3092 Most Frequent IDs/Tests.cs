using JetBrains.Annotations;

namespace LeetCode.Problems._3092_Most_Frequent_IDs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MostFrequentIDs(testCase.Nums, testCase.Freq), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Freq { get; [UsedImplicitly] init; } = null!;
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
