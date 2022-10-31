using JetBrains.Annotations;

namespace LeetCode._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833796085/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution09 : ISolution
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

        var queriesSet = queries.ToHashSet();
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

            var chainValue = node.val;

            while (chainValue != Missing)
            {
                if (queriesSet.Contains(chainValue))
                {
                    if (!valueLeavesMap.ContainsKey(chainValue))
                    {
                        valueLeavesMap[chainValue] = new HashSet<int>();
                    }

                    valueLeavesMap[chainValue].Add(node.val);
                }

                chainValue = valueParentMap[chainValue];
            }
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
            if (cache.ContainsKey(query))
            {
                return cache[query];
            }

            var leavesWithinQuery = valueLeavesMap[query];

            var maxLeaf = leaves.FirstOrDefault(leaf => !leavesWithinQuery.Contains(leaf));

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
