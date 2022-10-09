using NUnit.Framework;

namespace LeetCode._0023_Merge_k_Sorted_Lists;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var lists = testCase.ListValuesArr.Select(ListNode.CreateOrNull).ToArray();

        Assert.That(solution.MergeKLists(lists), Is.EqualTo(ListNode.CreateOrNull(testCase.ReturnValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] ListValuesArr { get; private init; } = null!;
        public int[] ReturnValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ListValuesArr = new[]
                    {
                        new[] { 1, 4, 5 },
                        new[] { 1, 3, 4 },
                        new[] { 2, 6 },
                    },
                    ReturnValues = new[] { 1, 1, 2, 3, 4, 4, 5, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ListValuesArr = Array.Empty<int[]>(),
                    ReturnValues = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    ListValuesArr = new[] { Array.Empty<int>() },
                    ReturnValues = Array.Empty<int>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
