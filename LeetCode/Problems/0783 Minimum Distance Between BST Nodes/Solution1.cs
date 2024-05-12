using JetBrains.Annotations;

namespace LeetCode.Problems._0783_Minimum_Distance_Between_BST_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/899436464/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDiffInBST(TreeNode root)
    {
        var result = int.MaxValue;

        Dfs(root);

        return result;

        void Dfs(TreeNode? node)
        {
            while (node != null)
            {
                if (node.left != null)
                {
                    result = Math.Min(result, node.val - MaxInTree(node.left));
                }

                if (node.right != null)
                {
                    result = Math.Min(result, MinInTree(node.right) - node.val);
                }

                Dfs(node.left);
                node = node.right;
            }
        }
    }

    private static int MinInTree(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }

        return node.val;
    }

    private static int MaxInTree(TreeNode node)
    {
        while (node.right != null)
        {
            node = node.right;
        }

        return node.val;
    }
}
