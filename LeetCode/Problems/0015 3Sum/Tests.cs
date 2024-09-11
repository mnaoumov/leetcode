using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0015_3Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ThreeSum(testCase.Nums),
            IsEquivalentToIgnoringItemOrder(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;

    }
}
