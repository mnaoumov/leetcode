
using JetBrains.Annotations;

namespace LeetCode.Problems._2602_Minimum_Operations_to_Make_All_Array_Elements_Equal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinOperations(testCase.Nums, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<long> Output { get; [UsedImplicitly] init; } = null!;
    }
}
