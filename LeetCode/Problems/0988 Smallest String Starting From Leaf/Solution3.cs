using System.Text;
using JetBrains.Annotations;

namespace LeetCode._0988_Smallest_String_Starting_From_Leaf;

/// <summary>
/// https://leetcode.com/submissions/detail/1234452657/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string SmallestFromLeaf(TreeNode root)
    {
        var parentsMap = new Dictionary<TreeNode, TreeNode>();
        var leaves = new List<TreeNode>();
        Dfs(root, root);

        var sb = new StringBuilder();
        var nodes = leaves;

        while (nodes.Count > 0)
        {
            var minValue = nodes.Min(node => node.val);
            var parentNodes = new List<TreeNode>();

            foreach (var node in nodes.Where(node => node.val == minValue))
            {
                if (ReferenceEquals(node, root))
                {
                    parentNodes.Clear();
                    break;
                }

                parentNodes.Add(parentsMap[node]);
            }

            nodes = parentNodes;
            sb.Append((char) (minValue + 'a'));
        }

        return sb.ToString();

        void Dfs(TreeNode node, TreeNode parent)
        {
            parentsMap[node] = parent;

            if (node.left != null)
            {
                Dfs(node.left,node);
            }

            if (node.right != null)
            {
                Dfs(node.right, node);
            }

            if (node.left == null && node.right == null)
            {
                leaves.Add(node);
            }
        }
    }
}
