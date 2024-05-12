using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._2187_Minimum_Time_to_Complete_Trips;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTime(testCase.Time, testCase.TotalTrips), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Time { get; [UsedImplicitly] init; } = null!;
        public int TotalTrips { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
