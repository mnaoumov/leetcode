using NUnit.Framework;

namespace LeetCode._004_Median_of_Two_Sorted_Arrays;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMedianSortedArrays(testCase.Nums1, testCase.Nums2), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums1 { get; private init; } = null!;
        public int[] Nums2 { get; private init; } = null!;
        public double ExpectedResult { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums1 = new[] { 1, 3 },
                    Nums2 = new[] { 2 },
                    ExpectedResult = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2 },
                    Nums2 = new[] { 3, 4 },
                    ExpectedResult = 2.5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums1 = Array.Empty<int>(),
                    Nums2 = new[] { 1 },
                    ExpectedResult = 1,
                    TestCaseName = "Empty"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 3 },
                    Nums2 = new[] { -2, -1 },
                    ExpectedResult = -1
                };
            }
        }
    }
}
