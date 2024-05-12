using JetBrains.Annotations;

namespace LeetCode.Problems._2747_Count_Zero_Request_Servers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-107/submissions/detail/978619528/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        var logObjs = logs.Select(arr => new Log(arr[0], arr[1])).OrderBy(l => l.Time).ToArray();

        var m = queries.Length;

        var ans = Enumerable.Repeat(n, m).ToArray();

        var orderedQueryIndices = Enumerable.Range(0, m).OrderBy(i => queries[i]).ToArray();

        var counts = new Dictionary<int, int>();
        const int queryIndexOfIndex = 0;
        var lowerBound = queries[orderedQueryIndices[queryIndexOfIndex]] - x;

        foreach (var log in logObjs)
        {
            if (log.Time < lowerBound)
            {
                continue;
            }

            counts.TryAdd(log.ServerId, 0);
            counts[log.ServerId]++;

            var queryIndex = orderedQueryIndices[queryIndexOfIndex];
            var query = queries[queryIndex];
            ans[queryIndex] = query;
        }

        return ans;
    }

    private record Log(int ServerId, int Time);
}
