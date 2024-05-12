
using JetBrains.Annotations;

namespace LeetCode.Problems._2523_Closest_Prime_Numbers_in_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ClosestPrimes(testCase.Left, testCase.Right), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
