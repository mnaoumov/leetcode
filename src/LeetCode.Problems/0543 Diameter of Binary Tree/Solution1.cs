namespace LeetCode.Problems._0543_Diameter_of_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/882868207/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int DiameterOfBinaryTree(TreeNode root) => 2 + MaxDepth(root.left) + MaxDepth(root.right);

    private static int MaxDepth(TreeNode? node)
    {
        if (node == null)
        {
            return -1;
        }

        var maxDepth = 1 + Math.Max(MaxDepth(node.left), MaxDepth(node.right));
        return maxDepth;
    }
}
