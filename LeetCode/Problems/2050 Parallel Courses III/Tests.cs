using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2050_Parallel_Courses_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTime(testCase.N, testCase.Relations, testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Relations { get; [UsedImplicitly] init; } = null!;
        public int[] Time { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
