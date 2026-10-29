namespace LeetCode.Problems._0865_Smallest_Subtree_with_all_the_Deepest_Nodes;

/// <summary>
/// https://leetcode.com/problems/smallest-subtree-with-all-the-deepest-nodes/submissions/1596275383/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode SubtreeWithAllDeepest(TreeNode root) => SubtreeWithAllDeepest2(root).lca!;

    private static (TreeNode? lca, int depth) SubtreeWithAllDeepest2(TreeNode? node)
    {
        if (node == null)
        {
            return (null, 0);
        }

        var (leftLca, leftDepth) = SubtreeWithAllDeepest2(node.left);
        var (rightLca, rightDepth) = SubtreeWithAllDeepest2(node.right);

        if (leftDepth == rightDepth)
        {
            return (node, leftDepth + 1);
        }

        return leftDepth > rightDepth
            ? (leftLca, leftDepth + 1)
            : (rightLca, rightDepth + 1);
    }
}

