using JetBrains.Annotations;

namespace LeetCode._0144_Binary_Tree_Preorder_Traversal;

/// <summary>
/// https://leetcode.com/problems/binary-tree-preorder-traversal/submissions/845326188/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> PreorderTraversal(TreeNode? root)
    {
        return Enumerate(root).ToArray();
    }

    private static IEnumerable<int> Enumerate(TreeNode? node)
    {
        if (node == null)
        {
            yield break;
        }

        yield return node.val;

        foreach (var childValue in Enumerate(node.left).Concat(Enumerate(node.right)))
        {
            yield return childValue;
        }
    }
}
