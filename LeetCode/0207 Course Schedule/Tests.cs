﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0207_Course_Schedule;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanFinish(testCase.NumCourses, testCase.Prerequisites), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int NumCourses { get; [UsedImplicitly] init; }
        public int[][] Prerequisites { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    NumCourses = 2,
                    Prerequisites = new[] { new[] { 1, 0 } },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    NumCourses = 2,
                    Prerequisites = new[] { new[] { 1, 0 }, new[] { 0, 1 } },
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}