using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2768_Number_of_Black_Blocks;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CountBlackBlocks(testCase.M, testCase.N, testCase.Coordinates), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[][] Coordinates { get; [UsedImplicitly] init; } = null!;
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
