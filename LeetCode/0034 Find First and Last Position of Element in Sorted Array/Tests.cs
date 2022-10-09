using NUnit.Framework;

namespace LeetCode._0034_Find_First_and_Last_Position_of_Element_in_Sorted_Array;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SearchRange(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 5, 7, 7, 8, 8, 10 },
                    Target = 8,
                    Output = new[] { 3, 4 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 5, 7, 7, 8, 8, 10 },
                    Target = 6,
                    Output = new[] { -1, -1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = Array.Empty<int>(),
                    Target = 0,
                    Output = new[] { -1, -1 },
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 2 },
                    Target = 1,
                    Output = new[] { 0, 1 },
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 2 },
                    Target = 2,
                    Output = new[] { 0, 1 },
                    TestCaseName = nameof(Solution3)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 4 },
                    Target = 4,
                    Output = new[] { 1, 1 },
                    TestCaseName = nameof(Solution4)
                };

                yield return new TestCase
                {
                    Nums = new[] { 5, 7, 7, 8, 8, 10 },
                    Target = 8,
                    Output = new[] { 3, 4 },
                    TestCaseName = nameof(Solution7)
                };
            }
        }
    }
}