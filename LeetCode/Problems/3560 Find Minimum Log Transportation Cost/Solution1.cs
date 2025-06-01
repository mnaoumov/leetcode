namespace LeetCode.Problems._3560_Find_Minimum_Log_Transportation_Cost;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-451/problems/find-minimum-log-transportation-cost/submissions/1643599009/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinCuttingCost(int n, int m, int k)
    {
        var ans = 0L;

        var availableSpaces = new List<int> { k, k, k };
        var logs = new List<int> { n, m };
        logs.Sort();

        while (logs.Count > 0)
        {
            var min = logs[0];
            const int noSpace = -1;
            var minSpace = availableSpaces.FirstOrDefault(s => s >= min, noSpace);
            if (minSpace == noSpace)
            {
                var maxSpace = availableSpaces[^1];
                ans += maxSpace * (min - maxSpace);
                availableSpaces.RemoveAt(availableSpaces.Count - 1);
                logs[0] -= maxSpace;
            }
            else
            {
                availableSpaces.Remove(minSpace);

                if (minSpace > min)
                {
                    availableSpaces.Add(minSpace - min);
                    availableSpaces.Sort();
                }

                logs.RemoveAt(0);
            }
        }

        return ans;
    }
}
