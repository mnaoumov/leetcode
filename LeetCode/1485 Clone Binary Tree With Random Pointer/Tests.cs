using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1485_Clone_Binary_Tree_With_Random_Pointer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = BuildNode(testCase.Root);
        var rootCopy = solution.CopyRandomBinaryTree(root);

        var nodeToNodeCopyMap = new Dictionary<Node, NodeCopy>();
        var nodeCopyToNodeMap = new Dictionary<NodeCopy, Node>();

        AssertIsCopy(root, rootCopy);

        void AssertIsCopy(Node? node, NodeCopy? nodeCopy)
        {
            if (node == null || nodeCopy == null)
            {
                Assert.That(node, Is.Null);
                Assert.That(nodeCopy, Is.Null);
            }
            else if (nodeToNodeCopyMap.ContainsKey(node))
            {
                Assert.That(nodeToNodeCopyMap[node], Is.EqualTo(nodeCopy),
                    $"Node {node.val} is already mapped to NodeCopy {nodeToNodeCopyMap[node].val} rather than {nodeCopy.val}");
            }
            else if (nodeCopyToNodeMap.ContainsKey(nodeCopy))
            {
                Assert.That(nodeCopyToNodeMap[nodeCopy], Is.EqualTo(node),
                    $"NodeCopy {nodeCopy.val} is already mapped to Node {nodeCopyToNodeMap[nodeCopy].val} rather than {node.val}");
            }
            else
            {
                nodeToNodeCopyMap[node] = nodeCopy;
                nodeCopyToNodeMap[nodeCopy] = node;

                Assert.That(node.val, Is.EqualTo(nodeCopy.val));
                AssertIsCopy(node.left, nodeCopy.left);
                AssertIsCopy(node.right, nodeCopy.right);
                // ReSharper disable once TailRecursiveCall
                AssertIsCopy(node.random, nodeCopy.random);
            }
        }
    }

    private static Node? BuildNode(IReadOnlyList<int?[]?> values)
    {
        var nodes = new Node?[values.Count];
        var queue = new Queue<Node>();
        var result = CreateFromIndex(0);

        if (result == null)
        {
            return result;
        }

        queue.Enqueue(result);
        
        var index = 0;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            node.left = CreateFromIndex(index + 1);
            node.right = CreateFromIndex(index + 2);
            index += 2;

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }

        for (var i = 0; i < values.Count; i++)
        {
            var node = nodes[i];

            if (node == null)
            {
                continue;
            }

            if (values[i]![1] is { } randomIndex)
            {
                node.random = nodes[randomIndex];
            }
        }

        return nodes[0];

        Node? CreateFromIndex(int index2)
        {
            if (index2 >= values.Count || values[index2] == null)
            {
                return null;
            }

            var val = (int) values[index2]![0]!;
            nodes[index2] = new Node(val);
            return nodes[index2];
        }
    }

    public class TestCase : TestCaseBase
    {
        public int?[]?[] Root { get; [UsedImplicitly] init; } = null!;
    }
}
