using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1905_Count_Sub_Islands;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubIslands(testCase.Grid1, testCase.Grid2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Grid2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
