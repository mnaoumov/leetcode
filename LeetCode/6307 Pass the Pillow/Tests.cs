using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._6307_Pass_the_Pillow;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PassThePillow(testCase.N, testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Time { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
