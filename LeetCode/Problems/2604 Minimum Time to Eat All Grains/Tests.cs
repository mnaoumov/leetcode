using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2604_Minimum_Time_to_Eat_All_Grains;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTime(testCase.Hens, testCase.Grains), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Hens { get; [UsedImplicitly] init; } = null!;
        public int[] Grains { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
