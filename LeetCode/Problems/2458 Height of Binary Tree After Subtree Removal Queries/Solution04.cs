using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2458_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/833693594/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution04 : ISolution
{
    private const int Missing = -1;

    public int[] TreeQueries(TreeNode root, int[] queries)
    {
        var valueNodeMap = new Dictionary<int, TreeNode>();
        var valueParentMap = new Dictionary<int, int>();
        var valueLevelMap = new Dictionary<int, int>();
        var valueLeavesMap = new Dictionary<int, List<int>>();
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
                    valueLeavesMap[chainValue] = new List<int>();
                }

                valueLeavesMap[chainValue].Add(node.val);
                chainValue = valueParentMap[chainValue];
            }
        }

        return queries.Select(Get).ToArray();

        int Get(int query)
        {
            if (cache.TryGetValue(query, out var value))
            {
                return value;
            }

            var leaves = valueLeavesMap[root.val].ToHashSet();
            leaves.ExceptWith(valueLeavesMap[query]);
            var parent = valueNodeMap[valueParentMap[query]];

            if (parent.left == null || parent.right == null)
            {
                leaves.Add(parent.val);
            }

            return cache[query] = leaves.Select(leaf => valueLevelMap[leaf]).Max();
        }
    }
}
