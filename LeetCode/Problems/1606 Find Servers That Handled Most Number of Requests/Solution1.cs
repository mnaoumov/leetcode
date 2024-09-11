using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1606_Find_Servers_That_Handled_Most_Number_of_Requests;

/// <summary>
/// https://leetcode.com/submissions/detail/957989331/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<int> BusiestServers(int k, int[] arrival, int[] load)
    {
        var ans = new List<int>();

        var servers = new (int releaseTime, int requestCount)[k];
        var maxCount = 0;

        for (var i = 0; i < arrival.Length; i++)
        {
            var requestTime = arrival[i];

            for (var j = 0; j < k; j++)
            {
                var serverIndex = (i + j) % k;

                if (servers[serverIndex].releaseTime > requestTime)
                {
                    continue;
                }

                servers[serverIndex].releaseTime = requestTime + load[i];
                servers[serverIndex].requestCount++;

                if (servers[serverIndex].requestCount > maxCount)
                {
                    ans.Clear();
                    maxCount = servers[serverIndex].requestCount;
                }

                if (servers[serverIndex].requestCount == maxCount)
                {
                    ans.Add(serverIndex);
                }

                break;
            }
        }

        return ans;
    }
}
