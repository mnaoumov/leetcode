using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0458_Poor_Pigs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PoorPigs(testCase.Buckets, testCase.MinutesToDie, testCase.MinutesToTest), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Buckets { get; [UsedImplicitly] init; }
        public int MinutesToDie { get; [UsedImplicitly] init; }
        public int MinutesToTest { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
