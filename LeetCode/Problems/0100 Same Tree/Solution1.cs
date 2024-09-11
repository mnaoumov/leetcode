namespace LeetCode.Problems._0100_Same_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/829672106/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        if (p == null || q == null)
        {
            return p == null && q == null;
        }

        return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
