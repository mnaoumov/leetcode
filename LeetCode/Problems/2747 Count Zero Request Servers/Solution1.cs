using JetBrains.Annotations;

namespace LeetCode.Problems._2747_Count_Zero_Request_Servers;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-107/submissions/detail/978619528/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        var logObjs = logs.Select(arr => new Log(arr[0], arr[1])).OrderBy(l => l.Time).ToArray();

        var counts = new Dictionary<int, int>();
        var timeCountsMap = new Dictionary<int, Dictionary<int, int>>();

        var times = new SortedSet<int?>();

        foreach (var logObj in logObjs)
        {
            counts.TryAdd(logObj.ServerId, 0);
            counts[logObj.ServerId]++;
            timeCountsMap[logObj.Time] = new Dictionary<int, int>(counts);
            times.Add(logObj.Time);
        }

        var m = queries.Length;

        var ans = new int[m];

        for (var i = 0; i < m; i++)
        {
            var query = queries[i];

            var includeTime = times.GetViewBetween(int.MinValue, query).Max;
            var excludeTime = times.GetViewBetween(int.MinValue, query - x - 1).Max;

            var includeCounts = includeTime == null ? new Dictionary<int, int>() : timeCountsMap[includeTime.Value];
            var excludeCounts = excludeTime == null ? new Dictionary<int, int>() : timeCountsMap[excludeTime.Value];

            ans[i] = n;

            foreach (var (serverId, includeCount) in includeCounts)
            {
                if (excludeCounts.GetValueOrDefault(serverId) < includeCount)
                {
                    ans[i]--;
                }
            }
        }

        return ans;
    }

    private record Log(int ServerId, int Time);
}
