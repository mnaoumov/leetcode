using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0023_Merge_k_Sorted_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var lists = testCase.ListValuesArr.Select(ListNode.CreateOrNull).ToArray();

        Assert.That(solution.MergeKLists(lists), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] ListValuesArr { get; private init; } = null!;
        public int[] OutputValues { get; private init; } = null!;

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
                        new[] { 2, 6 }
                    },
                    OutputValues = new[] { 1, 1, 2, 3, 4, 4, 5, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ListValuesArr = Array.Empty<int[]>(),
                    OutputValues = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    ListValuesArr = new[] { Array.Empty<int>() },
                    OutputValues = Array.Empty<int>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
