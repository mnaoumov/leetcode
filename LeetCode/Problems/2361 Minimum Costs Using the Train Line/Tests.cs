using JetBrains.Annotations;

namespace LeetCode._2361_Minimum_Costs_Using_the_Train_Line;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinimumCosts(testCase.Regular, testCase.Express, testCase.ExpressCost), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Regular { get; [UsedImplicitly] init; } = null!;
        public int[] Express { get; [UsedImplicitly] init; } = null!;
        public int ExpressCost { get; [UsedImplicitly] init; }
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
