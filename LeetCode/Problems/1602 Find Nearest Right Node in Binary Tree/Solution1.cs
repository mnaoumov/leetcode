using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1602_Find_Nearest_Right_Node_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/950454326/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? FindNearestRightNode(TreeNode root, TreeNode u)
    {
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var uSeen = false;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (uSeen)
                {
                    return node;
                }

                if (ReferenceEquals(node, u))
                {
                    uSeen = true;
                    continue;
                }

                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }

            if (uSeen)
            {
                return null;
            }
        }

        return null;
    }
}
