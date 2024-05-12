using JetBrains.Annotations;

namespace LeetCode._1485_Clone_Binary_Tree_With_Random_Pointer;

/// <summary>
/// https://leetcode.com/submissions/detail/915382923/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public NodeCopy? CopyRandomBinaryTree(Node? root)
    {
        var nodeToNodeCopyMap = new Dictionary<Node, NodeCopy>();
        var rootCopy = MakeCopy(root);

        foreach (var (node, nodeCopy) in nodeToNodeCopyMap)
        {
            if (node.random != null)
            {
                nodeCopy.random = nodeToNodeCopyMap[node.random];
            }
        }

        return rootCopy;

        NodeCopy? MakeCopy(Node? node)
        {
            if (node == null)
            {
                return null;
            }

            var nodeCopy = new NodeCopy
            {
                val = node.val,
                left = MakeCopy(node.left),
                right = MakeCopy(node.right)
            };
            nodeToNodeCopyMap[node] = nodeCopy;
            return nodeCopy;
        }
    }
}
