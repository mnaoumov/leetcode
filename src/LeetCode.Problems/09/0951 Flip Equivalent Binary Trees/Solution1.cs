namespace LeetCode.Problems._0951_Flip_Equivalent_Binary_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/1431931262/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool FlipEquiv(TreeNode? root1, TreeNode? root2)
    {
        if (root1 == null && root2 == null)
        {
            return true;
        }

        if (root1 == null || root2 == null)
        {
            return false;
        }

        if (root1.val != root2.val)
        {
            return false;
        }

        return FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right) ||
               FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left);
    }
}
