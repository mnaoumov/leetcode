
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2657_Find_the_Prefix_Common_Array_of_Two_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindThePrefixCommonArray(testCase.A, testCase.B), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] A { get; [UsedImplicitly] init; } = null!;
        public int[] B { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
