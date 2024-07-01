using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3200_Maximum_Height_of_a_Triangle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxHeightOfTriangle(testCase.Red, testCase.Blue), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Red { get; [UsedImplicitly] init; }
        public int Blue { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
