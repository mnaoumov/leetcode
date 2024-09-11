using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0112_Path_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/829095791/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

        return root.right != null && HasPathSum(root.right, targetSum - root.val);
    }
}
