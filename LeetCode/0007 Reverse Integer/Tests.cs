﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0007_Reverse_Integer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Reverse(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 123,
                    Output = 321,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = -123,
                    Output = -321,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 120,
                    Output = 21,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    X = -2147483648,
                    Output = 0,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
