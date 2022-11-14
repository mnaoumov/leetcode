﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0200_Number_of_Islands;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumIslands(testCase.Grid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { '1', '1', '1', '1', '0' },
                        new[] { '1', '1', '0', '1', '0' },
                        new[] { '1', '1', '0', '0', '0' },
                        new[] { '0', '0', '0', '0', '0' }
                    },
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { '1', '1', '0', '0', '0' },
                        new[] { '1', '1', '0', '0', '0' },
                        new[] { '0', '0', '1', '0', '0' },
                        new[] { '0', '0', '0', '1', '1' }
                    },
                    Output = 3,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { '1', '1', '1', '1', '1' },
                        new[] { '1', '0', '1', '0', '1' },
                        new[] { '1', '1', '1', '1', '1' }
                    },
                    Output = 1,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[]
                        {
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1',
                            '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1'
                        }
                    },
                    Output = 1,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[]
                        {
                            '1', '0', '0', '1', '1', '1', '0', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0', '0',
                            '0', '0'
                        },
                        new[]
                        {
                            '1', '0', '0', '1', '1', '0', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1', '0', '0',
                            '1', '0'
                        },
                        new[]
                        {
                            '0', '0', '0', '1', '1', '1', '1', '0', '1', '0', '1', '1', '0', '0', '0', '0', '1', '0',
                            '1', '0'
                        },
                        new[]
                        {
                            '0', '0', '0', '1', '1', '0', '0', '1', '0', '0', '0', '1', '1', '1', '0', '0', '1', '0',
                            '0', '1'
                        },
                        new[]
                        {
                            '0', '0', '0', '0', '0', '0', '0', '1', '1', '1', '0', '0', '0', '0', '0', '0', '0', '0',
                            '0', '0'
                        },
                        new[]
                        {
                            '1', '0', '0', '0', '0', '1', '0', '1', '0', '1', '1', '0', '0', '0', '0', '0', '0', '1',
                            '0', '1'
                        },
                        new[]
                        {
                            '0', '0', '0', '1', '0', '0', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1', '0', '1',
                            '0', '1'
                        },
                        new[]
                        {
                            '0', '0', '0', '1', '0', '1', '0', '0', '1', '1', '0', '1', '0', '1', '1', '0', '1', '1',
                            '1', '0'
                        },
                        new[]
                        {
                            '0', '0', '0', '0', '1', '0', '0', '1', '1', '0', '0', '0', '0', '1', '0', '0', '0', '1',
                            '0', '1'
                        },
                        new[]
                        {
                            '0', '0', '1', '0', '0', '1', '0', '0', '0', '0', '0', '1', '0', '0', '1', '0', '0', '0',
                            '1', '0'
                        },
                        new[]
                        {
                            '1', '0', '0', '1', '0', '0', '0', '0', '0', '0', '0', '1', '0', '0', '1', '0', '1', '0',
                            '1', '0'
                        },
                        new[]
                        {
                            '0', '1', '0', '0', '0', '1', '0', '1', '0', '1', '1', '0', '1', '1', '1', '0', '1', '1',
                            '0', '0'
                        },
                        new[]
                        {
                            '1', '1', '0', '1', '0', '0', '0', '0', '1', '0', '0', '0', '0', '0', '0', '1', '0', '0',
                            '0', '1'
                        },
                        new[]
                        {
                            '0', '1', '0', '0', '1', '1', '1', '0', '0', '0', '1', '1', '1', '1', '1', '0', '1', '0',
                            '0', '0'
                        },
                        new[]
                        {
                            '0', '0', '1', '1', '1', '0', '0', '0', '1', '1', '0', '0', '0', '1', '0', '1', '0', '0',
                            '0', '0'
                        },
                        new[]
                        {
                            '1', '0', '0', '1', '0', '1', '0', '0', '0', '0', '1', '0', '0', '0', '1', '0', '1', '0',
                            '1', '1'
                        },
                        new[]
                        {
                            '1', '0', '1', '0', '0', '0', '0', '0', '0', '1', '0', '0', '0', '1', '0', '1', '0', '0',
                            '0', '0'
                        },
                        new[]
                        {
                            '0', '1', '1', '0', '0', '0', '1', '1', '1', '0', '1', '0', '1', '0', '1', '1', '1', '1',
                            '0', '0'
                        },
                        new[]
                        {
                            '0', '1', '0', '0', '0', '0', '1', '1', '0', '0', '1', '0', '1', '0', '0', '1', '0', '0',
                            '1', '1'
                        },
                        new[]
                        {
                            '0', '0', '0', '0', '0', '0', '1', '1', '1', '1', '0', '1', '0', '0', '0', '1', '1', '0',
                            '0', '0'
                        }
                    },
                    Output = 58,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}