using JetBrains.Annotations;

namespace LeetCode._1660_Correct_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1080961237/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode CorrectBinaryTree(TreeNode root)
    {
        var ans = Clone(root)!;

        var queue = new Queue<(TreeNode node, TreeNode parent)>();
        queue.Enqueue((ans, ans));

        while (queue.Count > 0)
        {
            var count = queue.Count;
            var rightValueWrongNodeEntryMap = new Dictionary<int, (TreeNode parent, int nodeValue)>();

            for (var i = 0; i < count; i++)
            {
                var (node, parent) = queue.Dequeue();

                if (rightValueWrongNodeEntryMap.TryGetValue(node.val, out var wrongNodeEntry))
                {
                    if (wrongNodeEntry.parent.left?.val == wrongNodeEntry.nodeValue)
                    {
                        wrongNodeEntry.parent.left = null;
                    }
                    else
                    {
                        wrongNodeEntry.parent.right = null;
                    }
                }

                if (node.left != null)
                {
                    queue.Enqueue((node.left, node));
                }

                if (node.right == null)
                {
                    continue;
                }

                queue.Enqueue((node.right, node));
                rightValueWrongNodeEntryMap[node.right.val] = (parent, node.val);
            }
        }

        return ans;
    }

    private static TreeNode? Clone(TreeNode? node) =>
        node == null ? null : new TreeNode(node.val, Clone(node.left), Clone(node.right));
}
