﻿using NUnit.Framework;

namespace LeetCode._0718_Maximum_Length_of_Repeated_Subarray;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindLength(testCase.Nums1, testCase.Nums2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums1 { get; private init; } = null!;
        public int[] Nums2 { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums1 = new[] { 1, 2, 3, 2, 1 },
                    Nums2 = new[] { 3, 2, 1, 4, 7 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 0, 0, 0, 0, 0 },
                    Nums2 = new[] { 0, 0, 0, 0, 0 },
                    Output = 5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums1 = new[] { 0, 1, 1, 1, 1 },
                    Nums2 = new[] { 1, 0, 1, 0, 1 },
                    Output = 2,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}