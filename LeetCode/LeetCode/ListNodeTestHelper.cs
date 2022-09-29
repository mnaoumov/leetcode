using NUnit.Framework;

namespace LeetCode;

public static class ListNodeTestHelper
{
    public static void TestListNodesByReference(Func<ListNode?, ListNode?> listModificationFunc, int[] valuesBefore,
        int[] valuesAfter)
    {
        var listBefore = valuesBefore.Any() ? ListNode.Create(valuesBefore) : null;

        var valueToNodeMap = new Dictionary<int, ListNode>();

        var node = listBefore;

        while (node != null)
        {
            valueToNodeMap.Add(node.val, node);
            node = node.next;
        }

        var listAfter = listModificationFunc(listBefore);

        node = listAfter;

        foreach (var valueAfter in valuesAfter)
        {
            Assert.That(node, Is.SameAs(valueToNodeMap[valueAfter]));
            node = node!.next;
        }

        Assert.That(node, Is.Null);
    }
}