using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2801_Count_Stepping_Numbers_in_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSteppingNumbers(testCase.Low, testCase.High), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Low { get; [UsedImplicitly] init; } = null!;
        public string High { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
