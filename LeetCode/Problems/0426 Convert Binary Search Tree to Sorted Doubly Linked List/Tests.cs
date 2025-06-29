namespace LeetCode.Problems._0426_Convert_Binary_Search_Tree_to_Sorted_Doubly_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var doublyList = solution.TreeToDoublyList(Node.Create(testCase.Root));
        var values = new List<int>();

        var node = doublyList;

        var previousNode = node;

        while (true)
        {
            Assert.That(node, Is.Not.Null);

            if (values.Count > 0)
            {
                Assert.That(node!.left, Is.EqualTo(previousNode));
            }

            if (values.Count > 0 && values[0] == node!.val)
            {
                break;
            }

            values.Add(node!.val);
            previousNode = node;
            node = node.right;
        }

        Assert.That(values, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Root { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
