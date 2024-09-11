namespace LeetCode.Problems._3243_Shortest_Distance_After_Road_Addition_Queries_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-409/submissions/detail/1343706171/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        var m = queries.Length;
        var ans = new int[m];

        var adjNodes = Enumerable.Range(0, n - 1).Select(i => new List<int> { i + 1 }).ToArray();

        for (var i = 0; i < m; i++)
        {
            var query = queries[i];
            var u = query[0];
            var v = query[1];
            adjNodes[u].Add(v);
            var pq = new PriorityQueue<(int city, int time), int>();
            pq.Enqueue((0, 0), 0);

            while (true)
            {
                var (city, time) = pq.Dequeue();
                if (city == n - 1)
                {
                    ans[i] = time;
                    break;
                }

                foreach (var adjNode in adjNodes[city])
                {
                    pq.Enqueue((adjNode, time + 1), time + 1);
                }
            }
        }

        return ans;
    }
}
