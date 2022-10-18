using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0502_IPO;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaximizedCapital(testCase.K, testCase.W, testCase.Profits, testCase.Capital), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int K { get; private init; }
        public int W { get; private init; }
        public int[] Profits { get; private init; } = null!;
        public int[] Capital { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    K = 2,
                    W = 0,
                    Profits = new[] { 1, 2, 3 },
                    Capital = new[] { 0, 1, 1 },
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    K = 3,
                    W = 0,
                    Profits = new[] { 1, 2, 3 },
                    Capital = new[] { 0, 1, 2 },
                    Output = 6,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    K = 50000,
                    W = 50000,
                    Profits = Enumerable.Range(0, 50000).ToArray(),
                    Capital = new[] { 1, 2, 3 },
                    Output = 50003,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    K = 10,
                    W = 0,
                    Profits = new[] { 1, 2, 3 },
                    Capital = new[] { 0, 1, 2 },
                    Output = 6,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}