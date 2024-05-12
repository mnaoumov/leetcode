
using JetBrains.Annotations;

namespace LeetCode.Problems._2225_Find_Players_With_Zero_or_One_Losses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindWinners(testCase.Matches), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Matches { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
