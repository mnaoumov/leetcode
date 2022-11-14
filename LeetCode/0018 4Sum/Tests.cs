using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0018_4Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FourSum(testCase.Nums, testCase.Target),
            IsEquivalentToIgnoringItemOrder(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}