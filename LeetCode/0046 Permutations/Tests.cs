﻿using NUnit.Framework;

namespace LeetCode._0046_Permutations;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Permute(testCase.Nums), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public IList<IList<int>> Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3 },
                    Return = new IList<int>[]
                    {
                        new[] { 1, 2, 3 },
                        new[] { 1, 3, 2 },
                        new[] { 2, 1, 3 },
                        new[] { 2, 3, 1 },
                        new[] { 3, 1, 2 },
                        new[] { 3, 2, 1 }
                    },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    Return = new IList<int>[]
                    {
                        new[] { 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}