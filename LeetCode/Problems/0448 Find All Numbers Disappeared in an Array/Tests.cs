
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0448_Find_All_Numbers_Disappeared_in_an_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindDisappearedNumbers(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
