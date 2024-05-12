using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2511_Maximum_Enemy_Forts_That_Can_Be_Captured;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CaptureForts(testCase.Forts), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Forts { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
