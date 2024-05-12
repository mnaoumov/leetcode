using JetBrains.Annotations;

namespace LeetCode._0723_Candy_Crush;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CandyCrush(testCase.Board), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Board { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
