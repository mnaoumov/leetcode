using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode.Problems._0029_Divide_Two_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Divide(testCase.Dividend, testCase.Divisor), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Dividend { get; [UsedImplicitly] init; }
        public int Divisor { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
