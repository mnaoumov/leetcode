using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0621_Task_Scheduler;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LeastInterval(testCase.Tasks, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[] Tasks { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
