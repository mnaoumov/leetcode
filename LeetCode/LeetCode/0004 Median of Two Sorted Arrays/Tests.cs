using NUnit.Framework;

namespace LeetCode._0004_Median_of_Two_Sorted_Arrays;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMedianSortedArrays(testCase.Nums1, testCase.Nums2), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums1 { get; private init; } = null!;
        public int[] Nums2 { get; private init; } = null!;
        public double Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums1 = new[] { 1, 3 },
                    Nums2 = new[] { 2 },
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2 },
                    Nums2 = new[] { 3, 4 },
                    Return = 2.5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums1 = Array.Empty<int>(),
                    Nums2 = new[] { 1 },
                    Return = 1,
                    TestCaseName = "Empty"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 3 },
                    Nums2 = new[] { -2, -1 },
                    Return = -1
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 3, 4 },
                    Nums2 = new[] { 1, 2 },
                    Return = 2.5
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2 },
                    Nums2 = new[] { 3, 4, 5 },
                    Return = 3
                };
            }
        }
    }
}
