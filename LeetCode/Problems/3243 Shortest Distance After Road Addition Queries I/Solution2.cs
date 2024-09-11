namespace LeetCode.Problems._3243_Shortest_Distance_After_Road_Addition_Queries_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-409/submissions/detail/1343718254/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        var m = queries.Length;
        var ans = new int[m];

        var distances = new int[n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                distances[i, j] = j - i;
            }
        }

        for (var k = 0; k < m; k++)
        {
            var query = queries[k];
            var u = query[0];
            var v = query[1];
            distances[u, v] = 1;

            for (var i = 0; i <= u; i++)
            {
                for (var j = v; j < n; j++)
                {
                    distances[i, j] = Math.Min(distances[i, j], distances[i, u] + 1 + distances[v, j]);
                }
            }

            ans[k] = distances[0, n - 1];
        }

        return ans;
    }
}
