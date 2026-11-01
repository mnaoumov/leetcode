namespace LeetCode.Problems._0226_Invert_Binary_Tree;

/// <seealso href="https://leetcode.com/problems/invert-binary-tree/submissions/845554524/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? InvertTree(TreeNode? root)
    {
        if (root != null)
        {
            (root.left, root.right) = (InvertTree(root.right), InvertTree(root.left));
        }

        return root;
    }
}
