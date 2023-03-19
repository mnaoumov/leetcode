using JetBrains.Annotations;

namespace LeetCode._0114_Flatten_Binary_Tree_to_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/196749705/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void Flatten(TreeNode? root)
    {
        var node = root;
        while (node != null)
        {
            if (node.left != null)
            {
                GetRightmostNode(node.left).right = node.right;
                node.right = node.left;
                node.left = null;
            }
            node = node.right;
        }
    }

    private static TreeNode GetRightmostNode(TreeNode root)
    {
        var node = root;
        while (node.right != null)
        {
            node = node.right;
        }

        return node;
    }
}
