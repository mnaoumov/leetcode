using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2827_Number_of_Beautiful_Integers_in_the_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfBeautifulIntegers(testCase.Low, testCase.High, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
