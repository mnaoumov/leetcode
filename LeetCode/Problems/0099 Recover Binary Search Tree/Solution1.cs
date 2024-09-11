using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0099_Recover_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/829663570/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public void RecoverTree(TreeNode root)
    {
        RecoverTree(root, null, null);
    }

    private static bool RecoverTree(TreeNode? node, TreeNode? minNode, TreeNode? maxNode)
    {
        if (node == null)
        {
            return false;
        }

        if (minNode != null && minNode.val > node.val)
        {
            SwapNodes(node, minNode);
            return true;
        }

        // ReSharper disable once InvertIf
        if (maxNode != null && maxNode.val < node.val)
        {
            SwapNodes(node, maxNode);
            return true;
        }

        return RecoverTree(node.left, minNode, node) || RecoverTree(node.right, node, maxNode);
    }

    private static void SwapNodes(TreeNode node1, TreeNode node2) => (node2.val, node1.val) = (node1.val, node2.val);
}
