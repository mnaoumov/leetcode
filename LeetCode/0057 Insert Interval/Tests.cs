namespace LeetCode._0057_Insert_Interval;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Insert(testCase.Intervals, testCase.NewInterval), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Intervals { get; private init; } = null!;
        public int[] NewInterval { get; private init; } = null!;
        public int[][] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 3 }, new[] { 6, 9 } },
                    NewInterval = new[] { 2, 5 },
                    Output = new[] { new[] { 1, 5 }, new[] { 6, 9 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 2 }, new[] { 3, 5 }, new[] { 6, 7 }, new[] { 8, 10 }, new[] { 12, 16 } },
                    NewInterval = new[] { 4, 8 },
                    Output = new[] { new[] { 1, 2 }, new[] { 3, 10 }, new[] { 12, 16 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 5 } },
                    NewInterval = new[] { 2, 3 },
                    Output = new[] { new[] { 1, 5 } },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 5 }, new[] { 6, 8 } },
                    NewInterval = new[] { 0, 9 },
                    Output = new[] { new[] { 0, 9 } },
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Intervals = Array.Empty<int[]>(),
                    NewInterval = new[] { 5, 7 },
                    Output = new[] { new[] { 5, 7 } },
                    TestCaseName = nameof(Solution4)
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 1, 5 } },
                    NewInterval = new[] { 0, 0 },
                    Output = new[] { new[] { 0, 0 }, new[] { 1, 5 } },
                    TestCaseName = nameof(Solution5)
                };

                yield return new TestCase
                {
                    Intervals = new[] { new[] { 3, 5 }, new[] { 12, 15 } },
                    NewInterval = new[] { 6, 6 },
                    Output = new[] { new[] { 3, 5 }, new[] { 6, 6 }, new[] { 12, 15 } },
                    TestCaseName = nameof(Solution6)
                };
            }
        }
    }
}