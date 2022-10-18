﻿using JetBrains.Annotations;

namespace LeetCode._0056_Merge_Intervals;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.Merge(testCase.Intervals), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Intervals { get; private init; } = null!;
        public int[][] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 3 }, new[] { 2, 6 }, new[] { 8, 10 }, new[] { 15, 18 } },
                    Output = new[] { new[] { 1, 6 }, new[] { 8, 10 }, new[] { 15, 18 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 4 }, new[] { 4, 5 } },
                    Output = new[] { new[] { 1, 5 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 4 }, new[] { 0, 5 } },
                    Output = new[] { new[] { 0, 5 } },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}