using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0112_Path_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/814660488/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root == null)
        {
            return false;
        }

        if (root.left == null && root.right == null)
        {
            return targetSum == root.val;
        }

        if (root.left != null && HasPathSum(root.left, targetSum - root.val))
        {
            return true;
        }

        if (root.right != null && HasPathSum(root.right, targetSum - root.val))
        {
            return true;
        }

        return false;
    }
}