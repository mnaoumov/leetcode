using JetBrains.Annotations;

namespace LeetCode.Problems._0547_Number_of_Provinces;

/// <summary>
/// https://leetcode.com/submissions/detail/904393246/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;

        var neighbors = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (isConnected[i][j] == 1)
                {
                    neighbors[i].Add(j);
                }
            }
        }

        var seen = new HashSet<int>();

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            if (seen.Contains(i))
            {
                continue;
            }

            result++;

            var queue = new Queue<int>();
            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (!seen.Add(node))
                {
                    continue;
                }

                foreach (var neighbor in neighbors[node])
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return result;
    }
}
