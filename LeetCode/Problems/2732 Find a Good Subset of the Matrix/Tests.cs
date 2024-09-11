using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2732_Find_a_Good_Subset_of_the_Matrix;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GoodSubsetofBinaryMatrix(testCase.Grid), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
