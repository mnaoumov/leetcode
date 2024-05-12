using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2843_Count_Symmetric_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSymmetricIntegers(testCase.Low, testCase.High), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
