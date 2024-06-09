using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3175_Find_The_First_Player_to_win_K_Games_in_a_Row;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindWinningPlayer(testCase.Skills, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Skills { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
