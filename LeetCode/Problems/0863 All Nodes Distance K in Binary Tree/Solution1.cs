using JetBrains.Annotations;

namespace LeetCode._0863_All_Nodes_Distance_K_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/904845508/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        var parents = new Dictionary<TreeNode, TreeNode?>();

        Dfs(root, null);
        var result = new List<int>();
        var queue = new Queue<(TreeNode? node, int distance)>();
        queue.Enqueue((target, 0));
        var seen = new HashSet<TreeNode>();

        while (queue.Count > 0)
        {
            var (node, distance) = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            if (!seen.Add(node))
            {
                continue;
            }

            if (distance == k)
            {
                result.Add(node.val);
                continue;
            }

            queue.Enqueue((node.left, distance + 1));
            queue.Enqueue((node.right, distance + 1));
            queue.Enqueue((parents[node], distance + 1));
        }

        return result;

        void Dfs(TreeNode? node, TreeNode? parent)
        {
            while (node != null)
            {
                parents[node] = parent;
                Dfs(node.left, node);
                (node, parent) = (node.right, node);
            }
        }
    }
}
