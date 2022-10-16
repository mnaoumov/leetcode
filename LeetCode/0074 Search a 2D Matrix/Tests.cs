﻿using NUnit.Framework;

namespace LeetCode._0074_Search_a_2D_Matrix;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SearchMatrix(testCase.Matrix, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; private init; } = null!;
        public int Target { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } },
                    Target = 3,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[] { new[] { 1, 3, 5, 7 }, new[] { 10, 11, 16, 20 }, new[] { 23, 30, 34, 60 } },
                    Target = 13,
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}