using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1535_Find_the_Winner_of_an_Array_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetWinner(testCase.Arr, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
