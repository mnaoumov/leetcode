using NUnit.Framework;

namespace LeetCode._0128_Longest_Consecutive_Sequence;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestConsecutive(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 100, 4, 200, 1, 3, 2 },
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 },
                    Output = 9,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { -1, 1, 0 },
                    Output = 3,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 5, 2, 4 },
                    Output = 5,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}