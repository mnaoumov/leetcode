using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3001_Minimum_Moves_to_Capture_The_Queen;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMovesToCaptureTheQueen(testCase.A, testCase.B, testCase.C, testCase.D, testCase.E, testCase.F), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int C { get; [UsedImplicitly] init; }
        public int D { get; [UsedImplicitly] init; }
        public int E { get; [UsedImplicitly] init; }
        public int F { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
