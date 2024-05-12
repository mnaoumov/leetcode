using JetBrains.Annotations;

namespace LeetCode.Problems._2903_Find_Indices_With_Index_and_Value_Difference_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindIndices(testCase.Nums, testCase.IndexDifference, testCase.ValueDifference), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int IndexDifference { get; [UsedImplicitly] init; }
        public int ValueDifference { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
