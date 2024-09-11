using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2513_Minimize_the_Maximum_of_Two_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimizeSet(testCase.Divisor1, testCase.Divisor2, testCase.UniqueCnt1, testCase.UniqueCnt2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Divisor1 { get; [UsedImplicitly] init; }
        public int Divisor2 { get; [UsedImplicitly] init; }
        public int UniqueCnt1 { get; [UsedImplicitly] init; }
        public int UniqueCnt2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
