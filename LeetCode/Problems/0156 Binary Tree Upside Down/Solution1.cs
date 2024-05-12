using JetBrains.Annotations;

namespace LeetCode._0156_Binary_Tree_Upside_Down;

/// <summary>
/// https://leetcode.com/problems/binary-tree-upside-down/submissions/848306572/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? UpsideDownBinaryTree(TreeNode? root)
    {
        if (root == null)
        {
            return null;
        }

        if (root.left == null)
        {
            return root;
        }

        var newLeft = UpsideDownBinaryTree(root.left);

        root.left.left = root.right;
        root.left.right = root;
        root.left = null;
        root.right = null;

        return newLeft;
    }
}
