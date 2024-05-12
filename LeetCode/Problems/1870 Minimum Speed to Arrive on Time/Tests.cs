using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1870_Minimum_Speed_to_Arrive_on_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinSpeedOnTime(testCase.Dist, testCase.Hour), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Dist { get; [UsedImplicitly] init; } = null!;
        public double Hour { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
