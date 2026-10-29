namespace LeetCode.Problems._1372_Longest_ZigZag_Path_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905492803/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestZigZag(TreeNode root) => Dfs(root).totalMax;

    private static (int leftMax, int rightMax, int totalMax) Dfs(TreeNode? node)
    {
        if (node == null)
        {
            return (-1, -1, -1);
        }

        var leftResult = Dfs(node.left);
        var rightResult = Dfs(node.right);
        var leftMax = leftResult.rightMax + 1;
        var rightMax = rightResult.leftMax + 1;
        var totalMax = new[] { leftMax, rightMax, leftResult.totalMax, rightResult.totalMax }.Max();
        return (leftMax, rightMax, totalMax);
    }
}
