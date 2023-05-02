using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0334_Increasing_Triplet_Subsequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IncreasingTriplet(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
