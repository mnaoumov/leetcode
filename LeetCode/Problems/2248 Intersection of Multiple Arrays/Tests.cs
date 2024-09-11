
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2248_Intersection_of_Multiple_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Intersection(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Nums { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
