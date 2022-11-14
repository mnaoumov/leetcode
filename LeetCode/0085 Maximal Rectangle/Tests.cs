﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0085_Maximal_Rectangle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximalRectangle(testCase.Matrix), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '1', '0', '1', '0', '0' },
                        new[] { '1', '0', '1', '1', '1' },
                        new[] { '1', '1', '1', '1', '1' },
                        new[] { '1', '0', '0', '1', '0' }
                    },
                    Output = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '0' }
                    },
                    Output = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '1' }
                    },
                    Output = 1,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '1', '1', '1', '1', '1', '1', '1', '1' },
                        new[] { '1', '1', '1', '1', '1', '1', '1', '0' },
                        new[] { '1', '1', '1', '1', '1', '1', '1', '0' },
                        new[] { '1', '1', '1', '1', '1', '0', '0', '0' },
                        new[] { '0', '1', '1', '1', '1', '0', '0', '0' }
                    },
                    Output = 21,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}