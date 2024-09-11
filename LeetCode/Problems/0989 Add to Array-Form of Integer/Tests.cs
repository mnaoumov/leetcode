
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0989_Add_to_Array_Form_of_Integer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AddToArrayForm(testCase.Num, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Num { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
