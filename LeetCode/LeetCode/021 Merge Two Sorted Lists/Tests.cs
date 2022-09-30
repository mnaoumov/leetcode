using NUnit.Framework;

namespace LeetCode._021_Merge_Two_Sorted_Lists;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeTwoLists(ListNode.Create(testCase.List1Values), ListNode.Create(testCase.List2Values)), Is.EqualTo(ListNode.Create(testCase.ReturnValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] List1Values { get; private init; } = null!;
        public int[] List2Values { get; private init; } = null!;
        public int[] ReturnValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    List1Values = new[] { 1, 2, 4 },
                    List2Values = new[] { 1, 3, 4 },
                    ReturnValues = new[] { 1, 1, 2, 3, 4, 4 },
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}
