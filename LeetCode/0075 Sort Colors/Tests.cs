using NUnit.Framework;

namespace LeetCode._0075_Sort_Colors;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        solution.SortColors(nums);
        Assert.That(nums, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 0, 2, 1, 1, 0 },
                    Output = new[] { 0, 0, 1, 1, 2, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 0, 1 },
                    Output = new[] { 0, 1, 2 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2 },
                    Output = new[] { 2 },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}