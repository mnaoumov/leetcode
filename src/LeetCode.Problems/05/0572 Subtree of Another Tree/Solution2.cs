namespace LeetCode.Problems._0572_Subtree_of_Another_Tree;

/// <seealso href="https://leetcode.com/submissions/detail/935055140/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot) => IsSubtree(root, subRoot, false);

    private static bool IsSubtree(TreeNode? root, TreeNode? subRoot, bool isStarted)
    {
        if (root == null || subRoot == null)
        {
            return root == null && subRoot == null;
        }

        var result = root.val == subRoot.val && IsSubtree(root.left, subRoot.left, true) && IsSubtree(root.right, subRoot.right, true);

        return isStarted || result
            ? result
            : IsSubtree(root.left, subRoot, false) || IsSubtree(root.right, subRoot, false);
    }
}
