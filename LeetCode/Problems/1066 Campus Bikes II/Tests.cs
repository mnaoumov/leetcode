using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1066_Campus_Bikes_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AssignBikes(testCase.Workers, testCase.Bikes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Workers { get; [UsedImplicitly] init; } = null!;
        public int[][] Bikes { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
