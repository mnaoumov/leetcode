﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0072_Edit_Distance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDistance(testCase.Word1, testCase.Word2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Word1 { get; private init; } = null!;
        public string Word2 { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Word1 = "horse",
                    Word2 = "ros",
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Word1 = "intention",
                    Word2 = "execution",
                    Output = 5,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}