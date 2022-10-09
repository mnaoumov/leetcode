using NUnit.Framework;

namespace LeetCode._0237_Delete_Node_in_a_Linked_List;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = ListNode.Create(testCase.Values);
        var node = root.FindNode(testCase.NodeValue)!;
        solution.DeleteNode(node);
        Assert.That(root, Is.EqualTo(ListNode.Create(testCase.ReturnValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; private init; } = null!;
        public int[] ReturnValues { get; private init; } = null!;
        public int NodeValue { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 4, 5, 1, 9 },
                    NodeValue = 5,
                    ReturnValues = new[] { 4, 1, 9 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 4, 5, 1, 9 },
                    NodeValue = 1,
                    ReturnValues = new[] { 4, 5, 9 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}