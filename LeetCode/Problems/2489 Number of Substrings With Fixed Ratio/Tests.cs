using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2489_Number_of_Substrings_With_Fixed_Ratio;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FixedRatio(testCase.S, testCase.Num1, testCase.Num2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int Num1 { get; [UsedImplicitly] init; }
        public int Num2 { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
