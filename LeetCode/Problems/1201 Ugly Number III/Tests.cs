using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1201_Ugly_Number_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NthUglyNumber(testCase.N, testCase.A, testCase.B, testCase.C), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int C { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
