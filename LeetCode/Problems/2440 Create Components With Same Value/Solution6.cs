using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2440_Create_Components_With_Same_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/826694995/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution6 : ISolution
{
    public int ComponentValue(int[] nums, int[][] edges)
    {
        if (edges.Length == 0)
        {
            return 0;
        }

        var degrees = new int[nums.Length];
        var neighborsLists = new List<int>[nums.Length];

        foreach (var edge in edges)
        {
            ProcessNodeWithNeighbor(edge[0], edge[1]);
            ProcessNodeWithNeighbor(edge[1], edge[0]);

            void ProcessNodeWithNeighbor(int node, int neighbor)
            {
                degrees[node]++;
                neighborsLists[node] ??= new List<int>();
                neighborsLists[node].Add(neighbor);
            }
        }

        var totalSum = nums.Sum();
        var max = nums.Max();

        var queue = new Queue<int>();

        for (var node = 0; node < degrees.Length; node++)
        {
            if (degrees[node] == 1)
            {
                queue.Enqueue(node);
            }
        }


        for (var componentsCount = Math.Min(nums.Length, totalSum / max); componentsCount >= 2; componentsCount--)
        {
            if (totalSum % componentsCount != 0)
            {
                continue;
            }

            if (CheckIfPartitionPossible(componentsCount, nums.ToArray(), degrees.ToArray(), neighborsLists, totalSum, new Queue<int>(queue)))
            {
                return componentsCount - 1;
            }
        }

        return 0;
    }

    private static bool CheckIfPartitionPossible(int componentsCount, IList<int> nums, int[] degrees, IReadOnlyList<List<int>> neighbors, int totalSum, Queue<int> queue)
    {
        var componentSum = totalSum / componentsCount;

        while (queue.TryDequeue(out var leaf))
        {
            if (nums[leaf] > componentSum)
            {
                return false;
            }

            degrees[leaf] = 0;

            foreach (var parent in neighbors[leaf].Where(parent => degrees[parent] > 0))
            {
                degrees[parent]--;
                queue.Enqueue(parent);
                if (nums[leaf] < componentSum)
                {
                    nums[parent] += nums[leaf];
                }
            }
        }

        return true;
    }

}
