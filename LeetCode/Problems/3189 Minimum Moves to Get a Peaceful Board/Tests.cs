using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._3189_Minimum_Moves_to_Get_a_Peaceful_Board;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMoves(testCase.Rooks), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Rooks { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
