
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2545_Sort_the_Students_by_Their_Kth_Score;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SortTheStudents(testCase.Score, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Score { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
