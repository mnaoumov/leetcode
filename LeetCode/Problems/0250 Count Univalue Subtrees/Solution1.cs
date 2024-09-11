using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0250_Count_Univalue_Subtrees;

/// <summary>
/// https://leetcode.com/submissions/detail/982096181/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountUnivalSubtrees(TreeNode? root) => CountUnivalSubtrees2(root).count;

    private static (int count, bool isUnival) CountUnivalSubtrees2(TreeNode? node)
    {
        if (node == null)
        {
            return (0, true);
        }

        var (leftCount, isLeftUnival) = CountUnivalSubtrees2(node.left);
        var (rightCount, isRightUnival) = CountUnivalSubtrees2(node.right);

        var isUnival =
            isLeftUnival
            && isRightUnival
            && (node.left == null || node.left.val == node.val)
            && (node.right == null || node.right.val == node.val);

        var count = leftCount + rightCount + (isUnival ? 1 : 0);
        return (count, isUnival);
    }
}
