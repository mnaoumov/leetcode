using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0606_Construct_String_from_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/1115379342/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string Tree2str(TreeNode root) => Build(root)[1..^1];

    private static string Build(TreeNode? node, bool forceEmptyBraces = false) =>
        node == null
            ? forceEmptyBraces ? "()" : ""
            : $"({node.val}{Build(node.left, forceEmptyBraces: node.right != null)}{Build(node.right)})";
}
