// ReSharper disable All
#pragma warning disable
namespace LeetCode.Problems._0621_Task_Scheduler;

/// <summary>
/// https://leetcode.com/submissions/detail/196722409/
/// https://leetcode.com/submissions/detail/818858872/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution5_8 : ISolution
{
    public int LeastInterval(char[] tasks, int n)
    {
        int[] counts = new int[26];

        foreach (var task in tasks)
        {
            counts[task - 'A']++;
        }

        Array.Sort(counts);
        Array.Reverse(counts);

        var result = 0;

        while (counts[0] > 0)
        {
            int i;
            for (i = 0; i <= n && counts[i] > 0; i++)
            {
                counts[i]--;
                result++;
            }

            if (counts[0] == 0 && counts[i] == 0)
            {
                break;
            }

            result += n + 1 - i;

            Array.Sort(counts);
            Array.Reverse(counts);
        }

        return result;
    }
}
