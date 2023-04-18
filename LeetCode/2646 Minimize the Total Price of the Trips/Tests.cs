using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2646_Minimize_the_Total_Price_of_the_Trips;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTotalPrice(testCase.N, testCase.Edges, testCase.Price, testCase.Trips), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int[] Price { get; [UsedImplicitly] init; } = null!;
        public int[][] Trips { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
