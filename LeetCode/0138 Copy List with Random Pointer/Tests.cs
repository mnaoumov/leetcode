using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0138_Copy_List_with_Random_Pointer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = Node.Create(testCase.HeadValues);
        var copy = solution.CopyRandomList(head);

        var headList = GetNodesList(head);
        var copyList = GetNodesList(copy);

        Assert.That(copyList.Count, Is.EqualTo(headList.Count));

        for (var i = 0; i < copyList.Count; i++)
        {
            var headNode = headList[i];
            var copyNode = copyList[i];
            Assert.That(copyNode, Is.Not.SameAs(headNode));
            Assert.That(copyNode.val, Is.EqualTo(headNode.val));

            if (copyNode.random == null)
            {
                Assert.That(headNode.random, Is.Null);
            }
            else
            {
                Assert.That(headNode.random, Is.Not.Null);
                Assert.That(copyNode.random.val, Is.EqualTo(headNode.random!.val));
            }
        }
    }

    private static List<Node> GetNodesList(Node head)
    {
        var node = head;
        var list = new List<Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.next;
        }

        return list;
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[][] HeadValues { get; [UsedImplicitly] init; } = null!;
    }
}