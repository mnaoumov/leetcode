namespace LeetCode.Problems._1022_Sum_of_Root_To_Leaf_Binary_Numbers;

/// <summary>
/// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/submissions/1929074132/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumRootToLeaf(TreeNode root) => SumRootToLeaf(root, 0);

    private static int SumRootToLeaf(TreeNode node, int prefix)
    {
        var nextPrefix = 2 * prefix + node.val;

        if (node.left == null && node.right == null)
        {
            return nextPrefix;
        }

        var ans = 0;

        if (node.left != null)
        {
            ans += SumRootToLeaf(node.left, nextPrefix);
        }

        if (node.right != null)
        {
            ans += SumRootToLeaf(node.right, nextPrefix);
        }

        return ans;
    }
}
