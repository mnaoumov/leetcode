namespace LeetCode.Problems._0538_Convert_BST_to_Greater_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1299443056/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode ConvertBST(TreeNode root) => ConvertBST(root, 0).node!;

    private static (TreeNode? node, int leftmostVal) ConvertBST(TreeNode? node, int parentAddValue)
    {
        if (node == null)
        {
            return (null, 0);
        }

        var (right, leftmostValForRight) = ConvertBST(node.right, parentAddValue);
        var ans = new TreeNode
        {
            right = right,
            val = node.val + (right == null ? parentAddValue : leftmostValForRight)
        };
        var (left, leftmostValForLeft) = ConvertBST(node.left, ans.val);
        ans.left = left;
        return (ans, left != null ? leftmostValForLeft : ans.val);
    }
}
