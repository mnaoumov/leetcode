namespace LeetCode.Problems._0111_Minimum_Depth_of_Binary_Tree;

/// <seealso href="https://leetcode.com/submissions/detail/830892429/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDepth(TreeNode? root) =>
        root == null
            ? 0
            : 1 + (new[] { root.left, root.right }.Where(x => x != null).Select(x => (int?) MinDepth(x)).Min() ?? 0);
}
