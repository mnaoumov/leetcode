using JetBrains.Annotations;

namespace LeetCode._2440_Create_Components_With_Same_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/826374598/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
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
        }

        var totalSum = nums.Sum();
        var max = nums.Max();

        for (var componentsCount = Math.Min(nums.Length, totalSum / max); componentsCount >= 2; componentsCount--)
        {
            if (totalSum % componentsCount != 0)
            {
                continue;
            }

            if (CheckIfPartitionPossible2(componentsCount, nums.ToArray(), degrees.ToArray(), neighborsLists.Select(list => list.ToList()).ToArray(), totalSum))
            {
                return componentsCount - 1;
            }
        }

        return 0;

        void ProcessNodeWithNeighbor(int node, int neighbor)
        {
            degrees[node]++;
            neighborsLists[node] ??= new List<int>();
            neighborsLists[node].Add(neighbor);
        }
    }

    private static bool CheckIfPartitionPossible2(int componentsCount, IList<int> nums, int[] degrees, IReadOnlyList<List<int>> neighbors, int totalSum)
    {
        var componentSum = totalSum / componentsCount;

        while (componentsCount > 1)
        {
            var leaf = Array.IndexOf(degrees, 1);

            if (nums[leaf] > componentSum)
            {
                return false;
            }

            degrees[leaf] = 0;
            var parent = neighbors[leaf][0];
            degrees[parent]--;
            neighbors[parent].Remove(leaf);

            if (nums[leaf] < componentSum)
            {
                nums[parent] += nums[leaf];
            }
            else
            {
                componentsCount--;
            }
        }

        return true;
    }

}