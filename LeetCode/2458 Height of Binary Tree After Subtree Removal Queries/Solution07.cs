using JetBrains.Annotations;

namespace LeetCode._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833774853/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution07 : ISolution
{
    private const int Missing = -1;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        var valueNodeMap = new Dictionary<int, TreeNode>();
        var valueParentMap = new Dictionary<int, int>();
        var valueLevelMap = new Dictionary<int, int>();
        var valueLeavesMap = new Dictionary<int, HashSet<int>>();
        var cache = new Dictionary<int, int>();

        var queue = new Queue<(TreeNode node, int parentValue, int level)>();
        queue.Enqueue((root, Missing, 0));

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

            var chainValue = node.val;

            while (chainValue != Missing)
            {
                if (!valueLeavesMap.ContainsKey(chainValue))
                {
                    valueLeavesMap[chainValue] = new HashSet<int>();
                }

                valueLeavesMap[chainValue].Add(node.val);
                chainValue = valueParentMap[chainValue];
            }
        }

        var leaves = valueLeavesMap[root.val].OrderByDescending(leaf => valueLevelMap[leaf]).ToArray();

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

            var maxLeaf = leaves.FirstOrDefault(leaf => !valueLeavesMap[query].Contains(leaf));

            var result2 = maxLeaf == 0 ? 0 : valueLevelMap[maxLeaf];

            var parent = valueNodeMap[valueParentMap[query]];

            if (parent.left == null || parent.right == null)
            {
                result2 = Math.Max(result2, valueLevelMap[parent.val]);
            }

            return cache[query] = result2;
        }
    }
}
