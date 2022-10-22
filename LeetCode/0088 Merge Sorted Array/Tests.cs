using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0088_Merge_Sorted_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums1 = testCase.Nums1.ToArray();
        solution.Merge(nums1, testCase.M, testCase.Nums2, testCase.N);
        Assert.That(nums1, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums1 { get; private init; } = null!;
        public int M { get; private init; }
        public int[] Nums2 { get; private init; } = null!;
        public int N { get; private init; }
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2, 3, 0, 0, 0 },
                    M = 3,
                    Nums2 = new[] { 2, 5, 6 },
                    N = 3,
                    Output = new[] { 1, 2, 2, 3, 5, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 1 },
                    M = 1,
                    Nums2 = Array.Empty<int>(),
                    N = 0,
                    Output = new[] { 1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums1 = new [] { 0 },
                    M = 0,
                    Nums2 = new[] { 1 },
                    N = 1,
                    Output = new[] { 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}