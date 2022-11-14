using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1335_Minimum_Difficulty_of_a_Job_Schedule;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDifficulty(testCase.JobDifficulty, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] JobDifficulty { get; [UsedImplicitly] init; } = null!;
        public int D { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}