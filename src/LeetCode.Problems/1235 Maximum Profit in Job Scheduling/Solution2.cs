namespace LeetCode.Problems._1235_Maximum_Profit_in_Job_Scheduling;

/// <summary>
/// https://leetcode.com/submissions/detail/1138053798/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var records = startTime.Zip(endTime, profit).Cast<(int startTime, int endTime, int profit)>()
            .OrderBy(x => x.startTime).ThenBy(x => x.endTime).ToArray();

        var n = records.Length;
        var dp = new int[n + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            var result = dp[i + 1];
            int j;

            for (j = i + 1; j < n; j++)
            {
                if (records[j].startTime >= records[i].endTime)
                {
                    break;
                }
            }

            dp[i] = Math.Max(result, records[i].profit + dp[j]);
        }

        return dp[0];
    }
}
