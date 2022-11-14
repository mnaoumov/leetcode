﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0017_Letter_Combinations_of_a_Phone_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LetterCombinations(testCase.Digits), Is.EquivalentTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Digits { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Digits = "23",
                    Output = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Digits = "",
                    Output = Array.Empty<string>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Digits = "2",
                    Output = new[] { "a", "b", "c" },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
