using JetBrains.Annotations;

namespace LeetCode.Problems._1519_Number_of_Nodes_in_the_Sub_Tree_With_the_Same_Label;

/// <summary>
/// https://leetcode.com/submissions/detail/877087832/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CountSubTrees(int n, int[][] edges, string labels)
    {
        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            neighbors[edge[0]].Add(edge[1]);
            neighbors[edge[1]].Add(edge[0]);
        }

        var result = new int[n];

        Dfs(0, -1);

        return result;

        int[] Dfs(int node, int parent)
        {
            const int totalLabelCount = 26;
            var labelCounts = new int[totalLabelCount];
            var labelIndex = labels[node] - 'a';
            labelCounts[labelIndex]++;

            foreach (var neighbor in neighbors[node].Except(new[] { parent }))
            {
                var neighborLabelCounts = Dfs(neighbor, node);

                for (var i = 0; i < totalLabelCount; i++)
                {
                    labelCounts[i] += neighborLabelCounts[i];
                }
            }
            result[node] = labelCounts[labelIndex];
            return labelCounts;
        }
    }
}
