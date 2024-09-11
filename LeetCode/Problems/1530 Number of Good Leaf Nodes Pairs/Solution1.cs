namespace LeetCode.Problems._1530_Number_of_Good_Leaf_Nodes_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/1325697511/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int CountPairs(TreeNode root, int distance)
    {
        var adjNodes = new Dictionary<TreeNode, List<TreeNode>>();
        var leafNodes = new HashSet<TreeNode>();

        Dfs(root, null);

        var queue = new Queue<TreeNode>();

        foreach (var leafNode in leafNodes)
        {
            queue.Enqueue(leafNode);
        }

        var visited = new HashSet<TreeNode>();

        var currentDistance = 0;
        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();

                if (currentDistance > 0 && leafNodes.Contains(node))
                {
                    ans++;
                }

                if (!visited.Add(node))
                {
                    continue;
                }

                foreach (var adjNode in adjNodes[node])
                {
                    queue.Enqueue(adjNode);
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
