using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._0835_Image_Overlap;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        // public int LargestOverlap(int[][] img1, int[][] img2)
        Assert.That(solution.LargestOverlap(testCase.Img1, testCase.Img2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Img1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Img2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
