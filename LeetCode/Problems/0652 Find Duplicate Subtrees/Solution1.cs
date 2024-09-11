using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0652_Find_Duplicate_Subtrees;

/// <summary>
/// https://leetcode.com/submissions/detail/906195572/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
    {
        var hashes = new HashSet<string>();
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

            string hash;

            if (node.left == null && node.right == null)
            {
                hash = node.val.ToString();
            }
            else
            {
                var hashLeft = Dfs(node.left);
                var hashRight = Dfs(node.right);
                hash = $"L({hashLeft})R({hashRight})";
            }

            if (!hashes.Add(hash) && resultHashes.Add(hash))
            {
                result.Add(node);
            }

            return hash;
        }
    }
}
