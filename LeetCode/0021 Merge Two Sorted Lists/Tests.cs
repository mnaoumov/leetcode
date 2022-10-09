using NUnit.Framework;

namespace LeetCode._0021_Merge_Two_Sorted_Lists;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeTwoLists(ListNode.Create(testCase.List1Values), ListNode.Create(testCase.List2Values)), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] List1Values { get; private init; } = null!;
        public int[] List2Values { get; private init; } = null!;
        public int[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    List1Values = new[] { 1, 2, 4 },
                    List2Values = new[] { 1, 3, 4 },
                    OutputValues = new[] { 1, 1, 2, 3, 4, 4 },
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}
