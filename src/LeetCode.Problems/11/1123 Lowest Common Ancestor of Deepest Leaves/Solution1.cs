namespace LeetCode.Problems._1123_Lowest_Common_Ancestor_of_Deepest_Leaves;

/// <summary>
/// https://leetcode.com/problems/lowest-common-ancestor-of-deepest-leaves/submissions/1596273104/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode LcaDeepestLeaves(TreeNode root) => LcaDeepestLeaves2(root).lca!;

    private static (TreeNode? lca, int depth) LcaDeepestLeaves2(TreeNode? node)
    {
        if (node == null)
        {
            return (null, 0);
        }

        var (leftLca, leftDepth) = LcaDeepestLeaves2(node.left);
        var (rightLca, rightDepth) = LcaDeepestLeaves2(node.right);

        if (leftDepth == rightDepth)
        {
            return (node, leftDepth + 1);
        }

        return leftDepth > rightDepth
            ? (leftLca, leftDepth + 1)
            : (rightLca, rightDepth + 1);
    }
}
