namespace LeetCode.Problems._0285_Inorder_Successor_in_BST;

/// <summary>
/// https://leetcode.com/problems/inorder-successor-in-bst/submissions/1690156446/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (p.val == root.val)
        {
            return LeftmostDescendant(root.right);
        }

        // ReSharper disable once InvertIf
        if (p.val < root.val)
        {
            var ans = InorderSuccessor(root.left!, p);
            return ans ?? root;
        }

        // ReSharper disable once TailRecursiveCall
        return InorderSuccessor(root.right!, p);
    }

    private static TreeNode? LeftmostDescendant(TreeNode? node)
    {
        if (node == null)
        {
            return null;
        }

        while (node.left != null)
        {
            node = node.left;
        }

        return node;
    }
}
