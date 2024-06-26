using JetBrains.Annotations;

namespace LeetCode.Problems._1038_Binary_Search_Tree_to_Greater_Sum_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1299441702/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode BstToGst(TreeNode root) => BstToGst(root, 0).node!;

    private static (TreeNode? node, int leftmostVal) BstToGst(TreeNode? node, int parentAddValue)
    {
        if (node == null)
        {
            return (null, 0);
        }

        var (right, leftmostValForRight) = BstToGst(node.right, parentAddValue);
        var ans = new TreeNode
        {
            right = right,
            val = node.val + (right == null ? parentAddValue : leftmostValForRight)
        };
        var (left, leftmostValForLeft) = BstToGst(node.left, ans.val);
        ans.left = left;
        return (ans, left != null ? leftmostValForLeft : ans.val);
    }
}
