using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0004_Median_of_Two_Sorted_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMedianSortedArrays(testCase.Nums1, testCase.Nums2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums1 { get; private init; } = null!;
        public int[] Nums2 { get; private init; } = null!;
        public double Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums1 = new[] { 1, 3 },
                    Nums2 = new[] { 2 },
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2 },
                    Nums2 = new[] { 3, 4 },
                    Output = 2.5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums1 = Array.Empty<int>(),
                    Nums2 = new[] { 1 },
                    Output = 1,
                    TestCaseName = nameof(Solution01)
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 3, 4 },
                    Nums2 = new[] { 1, 2 },
                    Output = 2.5,
                    TestCaseName = nameof(Solution05_13) + " (5)"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 3 },
                    Nums2 = new[] { -2, -1 },
                    Output = -1,
                    TestCaseName = nameof(Solution11)
                };


                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2 },
                    Nums2 = new[] { 3, 4, 5 },
                    Output = 3,
                    TestCaseName = nameof(Solution05_13) + " (13)"
                };
            }
        }
    }
}
