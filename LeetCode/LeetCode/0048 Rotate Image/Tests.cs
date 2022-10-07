﻿namespace LeetCode._0048_Rotate_Image;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var matrix = testCase.Matrix.Select(row => row.ToArray()).ToArray();
        solution.Rotate(matrix);
        AssertCollectionEqualWithDetails(matrix, testCase.Return);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; private init; } = null!;
        public int[][] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 1, 2, 3 },
                        new[] { 4, 5, 6 },
                        new[] { 7, 8, 9 }
                    },
                    Return = new[]
                    {
                        new[] { 7, 4, 1 },
                        new[] { 8, 5, 2 },
                        new[] { 9, 6, 3 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 5, 1, 9, 11 },
                        new[] { 2, 4, 8, 10 },
                        new[] { 13, 3, 6, 7 },
                        new[] { 15, 14, 12, 16 }
                    },
                    Return = new[]
                    {
                        new[] { 15, 13, 2, 5 },
                        new[] { 14, 3, 4, 1 },
                        new[] { 12, 6, 8, 9 },
                        new[] { 16, 7, 10, 11 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}