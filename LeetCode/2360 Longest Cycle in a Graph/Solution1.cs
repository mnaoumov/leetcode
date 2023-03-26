using JetBrains.Annotations;

namespace LeetCode._2360_Longest_Cycle_in_a_Graph;

/// <summary>
/// 
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
            var cycleLength = 0;

            while (true)
            {
                if (node == -1)
                {
                    break;
                }

                if (seen[node])
                {
                    break;
                }

                if (node == i && cycleLength > 0)
                {
                    break;
                }

                cycleLength++;
                node = edges[node];
            }
        }

        return result;
    }
}
