using JetBrains.Annotations;

namespace LeetCode.Problems._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833834446/
/// </summary>
[UsedImplicitly]
public class Solution11 : ISolution
{
    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        var valueDepthMap = new Dictionary<int, int>();
        var valueHeightMap = new Dictionary<int, int>();

        var cache = new Dictionary<int, int>();

        var queue = new Queue<(TreeNode? node, int depth)>();
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            var (node, depth) = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            valueDepthMap[node.val] = depth;

            queue.Enqueue((node.left, depth + 1));
            queue.Enqueue((node.right, depth + 1));
        }

        var stack = new Stack<TreeNode?>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if (node == null)
            {
                continue;
            }

            if (valueHeightMap.ContainsKey(node.val))
            {
                continue;
            }

            if (node.left == null && node.right == null)
            {
                valueHeightMap[node.val] = 0;
                continue;
            }

            var leftHeight = TryGetHeight(node.left);
            var rightHeight = TryGetHeight(node.right);

            if (leftHeight != null && rightHeight != null)
            {
                valueHeightMap[node.val] = 1 + Math.Max((int) leftHeight, (int) rightHeight);
            }
            else
            {
                stack.Push(node);
                stack.Push(node.left);
                stack.Push(node.right);
            }
        }

        var depthValuesWithBiggestHeightMap = valueDepthMap
            .GroupBy(kvp => kvp.Value, kvp => kvp.Key)
            .ToDictionary(g => g.Key, g => g.OrderByDescending(value => valueHeightMap[value]).Take(2).ToArray());

        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            result[i] = Get(query);
        }

        return result;

        int? TryGetHeight(TreeNode? node)
        {
            if (node == null)
            {
                return -1;
            }

            if (valueHeightMap.TryGetValue(node.val, out var height))
            {
                return height;
            }

            return null;
        }


        int Get(int query)
        {
            if (cache.TryGetValue(query, out var value))
            {
                return value;
            }

            var depth = valueDepthMap[query];
            var valueWithTheSameDepthAndTheBiggestHeight = depthValuesWithBiggestHeightMap[depth].Except(new[] { query }).FirstOrDefault();

            if (valueWithTheSameDepthAndTheBiggestHeight == 0)
            {
                return cache[query] = depth - 1;
            }

            return cache[query] = depth + valueHeightMap[valueWithTheSameDepthAndTheBiggestHeight];
        }
    }
}
