using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0026_Remove_Duplicates_from_Sorted_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        var k = solution.RemoveDuplicates(nums);

        Assert.That(k, Is.EqualTo(testCase.ExpectedNums.Length));

        Assert.That(nums.Take(k), Is.EqualTo(testCase.ExpectedNums));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] ExpectedNums { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 2 },
                    ExpectedNums = new[] { 1, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 },
                    ExpectedNums = new[] { 0, 1, 2, 3, 4 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
