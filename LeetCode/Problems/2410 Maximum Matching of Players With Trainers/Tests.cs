using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._2410_Maximum_Matching_of_Players_With_Trainers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MatchPlayersAndTrainers(testCase.Players, testCase.Trainers), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Players { get; [UsedImplicitly] init; } = null!;
        public int[] Trainers { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
