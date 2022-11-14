﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0055_Jump_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanJump(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new []{ 2, 3, 1, 1, 4 },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new []{ 3, 2, 1, 0, 4 },
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}