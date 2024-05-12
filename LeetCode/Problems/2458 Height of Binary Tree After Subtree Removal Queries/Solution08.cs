using JetBrains.Annotations;

namespace LeetCode.Problems._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833789739/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution08 : ISolution
{
    private const int Missing = -1;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        var valueNodeMap = new Dictionary<int, TreeNode>();
        var valueParentMap = new Dictionary<int, int>();
        var valueLevelMap = new Dictionary<int, int>();
        var cache = new Dictionary<int, int>();

        var queue = new Queue<(TreeNode node, int parentValue, int level)>();
        queue.Enqueue((root, Missing, 0));

        var leaves = new List<int>();

        while (queue.Count > 0)
        {
            var (node, parentValue, level) = queue.Dequeue();

            valueNodeMap[node.val] = node;
            valueParentMap[node.val] = parentValue;
            valueLevelMap[node.val] = level;

            if (node.left != null)
            {
                queue.Enqueue((node.left, node.val, level + 1));
            }

            if (node.right != null)
            {
                queue.Enqueue((node.right, node.val, level + 1));
            }

            if (node.left != null || node.right != null)
            {
                continue;
            }

            leaves.Add(node.val);
        }

        leaves.Sort((leaf1, leaf2) => -valueLevelMap[leaf1].CompareTo(valueLevelMap[leaf2]));

        var result = new int[queries.Length];

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            result[i] = Get(query);
        }

        return result;

        int Get(int query)
        {
            if (cache.TryGetValue(query, out var value))
            {
                return value;
            }

            var queue2 = new Queue<TreeNode>();
            queue2.Enqueue(valueNodeMap[query]);

            var leavesWithinQueryNode = new HashSet<int>();

            while (queue2.Count > 0)
            {
                var node = queue2.Dequeue();

                if (node.left == null && node.right == null)
                {
                    leavesWithinQueryNode.Add(node.val);
                }

                if (node.left != null)
                {
                    queue2.Enqueue(node.left);
                }

                if (node.right != null)
                {
                    queue2.Enqueue(node.right);
                }
            }

            var result2 = leaves.Where(leaf => !leavesWithinQueryNode.Contains(leaf)).Select(leaf => valueLevelMap[leaf]).FirstOrDefault();

            var parent = valueNodeMap[valueParentMap[query]];

            if (parent.left == null || parent.right == null)
            {
                result2 = Math.Max(result2, valueLevelMap[parent.val]);
            }

            return cache[query] = result2;
        }
    }
}
