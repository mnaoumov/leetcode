using NUnit.Framework;

namespace LeetCode._0082_Remove_Duplicates_from_Sorted_List_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DeleteDuplicates(ListNode.CreateOrNull(testCase.Values)), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; private init; } = null!;
        public int[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 1, 2, 3, 3, 4, 4, 5 },
                    OutputValues = new[] { 1, 2, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 1, 1, 1, 2, 3 },
                    OutputValues = new[] { 2, 3 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int>(),
                    OutputValues = Array.Empty<int>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}