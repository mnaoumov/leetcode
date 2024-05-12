using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MostProfitablePath(testCase.Edges, testCase.Bob, testCase.Amount), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Bob { get; [UsedImplicitly] init; }
        public int[] Amount { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
