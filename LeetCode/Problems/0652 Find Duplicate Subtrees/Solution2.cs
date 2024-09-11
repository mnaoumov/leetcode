using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0652_Find_Duplicate_Subtrees;

/// <summary>
/// https://leetcode.com/submissions/detail/906197667/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        // ReSharper disable once RedundantAssignment
        var hashes = new HashSet<string>();
        // ReSharper disable once RedundantAssignment
        var resultHashes = new HashSet<string>();
        var result = new List<TreeNode>();
        Dfs(root);
        return result;

        string Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return "null";
            }

            var hashLeft = Dfs(node.left);
            var hashRight = Dfs(node.right);
            var hash = $"V({node.val})L({hashLeft})R({hashRight})";

            if (!hashes.Add(hash) && resultHashes.Add(hash))
            {
                result.Add(node);
            }

            return hash;
        }
    }
}
