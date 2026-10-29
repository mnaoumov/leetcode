namespace LeetCode.Problems._2895_Minimum_Processing_Time;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-366/submissions/detail/1069764479/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinProcessingTime(IList<int> processorTime, IList<int> tasks)
    {
        processorTime = processorTime.OrderBy(x => x).ToArray();
        tasks = tasks.OrderByDescending(x => x).ToArray();

        var n = processorTime.Count;

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < 4; j++)
            {
                ans = Math.Max(ans, processorTime[i] + tasks[4 * i + j]);
            }
        }

        return ans;
    }
}
