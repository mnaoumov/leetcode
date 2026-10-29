using System.Text.RegularExpressions;

namespace LeetCode.Problems._1028_Recover_a_Tree_From_Preorder_Traversal;

/// <summary>
/// https://leetcode.com/problems/recover-a-tree-from-preorder-traversal/submissions/1551222375/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode RecoverFromPreorder(string traversal)
    {
        var rootParent = new TreeNode();
        var nodesByDepth = new Dictionary<int, List<TreeNode>>
        {
            [-1] = new() { rootParent }
        };

        var regex = new Regex(@"(?<Depth>-*)(?<Value>\d+)");
        foreach (Match match in regex.Matches(traversal))
        {
            var depth = match.Groups["Depth"].Value.Length;
            var value = int.Parse(match.Groups["Value"].Value);
            var parentNode = nodesByDepth[depth - 1].Last();

            var node = new TreeNode(value);
            nodesByDepth.TryAdd(depth, new List<TreeNode>());
            nodesByDepth[depth].Add(node);

            if (parentNode.left == null)
            {
                parentNode.left = node;
            }
            else
            {
                parentNode.right = node;
            }
        }

        return rootParent.left!;
    }
}
