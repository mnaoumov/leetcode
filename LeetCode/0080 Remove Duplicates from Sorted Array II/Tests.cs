using NUnit.Framework;

namespace LeetCode._0080_Remove_Duplicates_from_Sorted_Array_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var k = solution.RemoveDuplicates(testCase.Nums);
        Assert.That(k, Is.EqualTo(testCase.ExpectedNums.Length));
        Assert.That(testCase.Nums.Take(k), Is.EqualTo(testCase.ExpectedNums));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[] ExpectedNums { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 1, 2, 2, 3 },
                    ExpectedNums = new[] { 1, 1, 2, 2, 3 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 },
                    ExpectedNums = new[] { 0, 0, 1, 1, 2, 3, 3 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}