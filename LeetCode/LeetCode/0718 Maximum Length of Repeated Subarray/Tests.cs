﻿using NUnit.Framework;

namespace LeetCode._0718_Maximum_Length_of_Repeated_Subarray;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution, Is.Not.Null);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Return = "foo",
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}