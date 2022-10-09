﻿// ReSharper disable All
#pragma warning disable CS8604
#pragma warning disable CS8625
namespace LeetCode._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/197168307/
/// </summary>
public class Solution2 : ISolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        var parents = new Dictionary<TreeNode, TreeNode>();

        FillParents(parents, root, null);

        var pAncestors = GetAncestors(parents, p);
        var qAncestors = GetAncestors(parents, q);

        int i;
        for (i = 0; i < pAncestors.Count && i < qAncestors.Count && pAncestors[i] == qAncestors[i]; i++)
        {
        }

        return pAncestors[i - 1];
    }

    private IList<TreeNode> GetAncestors(Dictionary<TreeNode, TreeNode> parents, TreeNode node)
    {
        var ancestors = new List<TreeNode>();
        while (node != null)
        {
            ancestors.Insert(0, node);
            node = parents[node];
        }

        return ancestors;
    }

    private void FillParents(Dictionary<TreeNode, TreeNode> parents, TreeNode node, TreeNode parent)
    {
        if (node == null)
        {
            return;
        }

        parents[node] = parent;

        FillParents(parents, node.left, node);
        FillParents(parents, node.right, node);
    }
}
