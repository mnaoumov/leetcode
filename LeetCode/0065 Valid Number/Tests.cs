﻿using NUnit.Framework;

namespace LeetCode._0065_Valid_Number;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsNumber(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "0",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "e",
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = ".",
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}