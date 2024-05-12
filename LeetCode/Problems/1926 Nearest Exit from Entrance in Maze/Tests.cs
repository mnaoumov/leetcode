using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1926_Nearest_Exit_from_Entrance_in_Maze;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NearestExit(testCase.Maze, testCase.Entrance), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Maze { get; [UsedImplicitly] init; } = null!;
        public int[] Entrance { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
