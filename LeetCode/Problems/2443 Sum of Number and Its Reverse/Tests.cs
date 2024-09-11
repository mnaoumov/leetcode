using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2443_Sum_of_Number_and_Its_Reverse;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SumOfNumberAndReverse(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
