using JetBrains.Annotations;

namespace LeetCode._1376_Time_Needed_to_Inform_All_Employees;

/// <summary>
/// https://leetcode.com/submissions/detail/906656719/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
        var subordinates = Enumerable.Range(0, n).ToDictionary(i => i, _ => new List<int>());

        for (var i = 0; i < manager.Length; i++)
        {
            if (manager[i] == -1)
            {
                continue;
            }
            subordinates[manager[i]].Add(i);
        }

        return Dfs(headID);

        int Dfs(int employeeId)
        {
            if (subordinates[employeeId].Count == 0)
            {
                return 0;
            }

            return informTime[employeeId] + subordinates[employeeId].Max(Dfs);
        }
    }
}
