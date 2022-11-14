using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0835_Image_Overlap;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        // public int LargestOverlap(int[][] img1, int[][] img2)
        Assert.That(solution.LargestOverlap(testCase.Img1, testCase.Img2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Img1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Img2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Img1 = new[] { new[] { 1, 1, 0 }, new[] { 0, 1, 0 }, new[] { 0, 1, 0 } },
                    Img2 = new[] { new[] { 0, 0, 0 }, new[] { 0, 1, 1 }, new[] { 0, 0, 1 } },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Img1 = new[] { new[] { 1 } },
                    Img2 = new[] { new[] { 1 } },
                    Output = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Img1 = new[] { new[] { 0 } },
                    Img2 = new[] { new[] { 0 } },
                    Output = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}