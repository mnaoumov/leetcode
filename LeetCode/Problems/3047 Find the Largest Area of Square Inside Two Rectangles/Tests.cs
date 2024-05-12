using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3047_Find_the_Largest_Area_of_Square_Inside_Two_Rectangles;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LargestSquareArea(testCase.BottomLeft, testCase.TopRight), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] BottomLeft { get; [UsedImplicitly] init; } = null!;
        public int[][] TopRight { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
