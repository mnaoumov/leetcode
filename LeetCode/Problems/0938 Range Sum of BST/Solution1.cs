using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0938_Range_Sum_of_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/855853129/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RangeSumBST(TreeNode? root, int low, int high)
    {
        if (root == null)
        {
            return 0;
        }

        var result = 0;

        if (low <= root.val && root.val <= high)
        {
            result += root.val;
        }

        if (root.val >= low)
        {
            result += RangeSumBST(root.left, low, high);
        }

        if (root.val <= high)
        {
            result += RangeSumBST(root.right, low, high);
        }

        return result;
    }
}
