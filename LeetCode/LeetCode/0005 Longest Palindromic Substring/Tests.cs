﻿using NUnit.Framework;

namespace LeetCode._0005_Longest_Palindromic_Substring;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestPalindrome(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "babad",
                    Return = "bab",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "cbbd",
                    Return = "bb",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "a",
                    Return = "a"
                };
            }
        }
    }
}