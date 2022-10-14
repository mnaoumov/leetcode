using NUnit.Framework;

namespace LeetCode._0081_Search_in_Rotated_Sorted_Array_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Search(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 5, 6, 0, 0, 1, 2 },
                    Target = 0,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 5, 6, 0, 0, 1, 2 },
                    Target = 3,
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 },
                    Target = 2,
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    Target = 0,
                    Output = false,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}