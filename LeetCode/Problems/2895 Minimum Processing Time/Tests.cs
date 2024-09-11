using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2895_Minimum_Processing_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinProcessingTime(testCase.ProcessorTime, testCase.Tasks), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> ProcessorTime { get; [UsedImplicitly] init; } = null!;
        public IList<int> Tasks { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
