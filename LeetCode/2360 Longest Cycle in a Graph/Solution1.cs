using JetBrains.Annotations;

namespace LeetCode._2360_Longest_Cycle_in_a_Graph;

/// <summary>
/// https://leetcode.com/submissions/detail/922267616/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestCycle(int[] edges)
    {
        var n = edges.Length;
        var seen = new bool[n];
        var result = -1;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            var node = i;

            var nodeIndexMap = new Dictionary<int, int>();

            while (true)
            {
                if (node == -1)
                {
                    break;
                }

                if (seen[node])
                {
                    if (nodeIndexMap.TryGetValue(node, out var index))
                    {
                        result = Math.Max(result, nodeIndexMap.Count - index);
                    }

                    break;
                }

                seen[node] = true;
                nodeIndexMap[node] = nodeIndexMap.Count;
                node = edges[node];
            }
        }

        return result;
    }
}
