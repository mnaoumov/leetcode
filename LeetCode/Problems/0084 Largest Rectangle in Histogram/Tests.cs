using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0084_Largest_Rectangle_in_Histogram;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LargestRectangleArea(testCase.Heights), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Heights { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
