using JetBrains.Annotations;

namespace LeetCode.Problems._1530_Number_of_Good_Leaf_Nodes_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/1325700323/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CountPairs(TreeNode root, int distance)
    {
        var adjNodes = new Dictionary<TreeNode, List<TreeNode>>();
        var leafNodes = new HashSet<TreeNode>();

        Dfs(root, null);

        var queue = new Queue<(TreeNode node, TreeNode initialLeafNode)>();

        foreach (var leafNode in leafNodes)
        {
            queue.Enqueue((leafNode, leafNode));
        }

        var visited = new HashSet<(TreeNode node, TreeNode initialLeafNode)>();

        var currentDistance = 0;
        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (node, initialLeafNode) = queue.Dequeue();

                if (!ReferenceEquals(node, initialLeafNode) && leafNodes.Contains(node))
                {
                    ans++;
                }

                if (!visited.Add((node, initialLeafNode)))
                {
                    continue;
                }

                foreach (var adjNode in adjNodes.GetValueOrDefault(node, new List<TreeNode>()))
                {
                    queue.Enqueue((adjNode, initialLeafNode));
                }
            }

            currentDistance++;
            if (currentDistance > distance)
            {
                break;
            }
        }

        ans /= 2;

        return ans;

        void Dfs(TreeNode? node, TreeNode? parent)
        {
            if (node == null)
            {
                return;
            }

            if (parent != null)
            {
                adjNodes.TryAdd(node, new List<TreeNode>());
                adjNodes[node].Add(parent);

                adjNodes.TryAdd(parent, new List<TreeNode>());
                adjNodes[parent].Add(node);
            }

            Dfs(node.left, node);
            Dfs(node.right, node);

            if (node.left == null && node.right == null)
            {
                leafNodes.Add(node);
            }
        }
    }
}
