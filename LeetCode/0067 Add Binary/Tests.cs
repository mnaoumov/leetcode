﻿using NUnit.Framework;

namespace LeetCode._0067_Add_Binary;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddBinary(testCase.A, testCase.B), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string A { get; private init; } = null!;
        public string B { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    A = "11",
                    B = "1",
                    Output = "100",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    A = "1010",
                    B = "1011",
                    Output = "10101",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}