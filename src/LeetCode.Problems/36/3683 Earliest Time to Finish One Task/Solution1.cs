namespace LeetCode.Problems._3683_Earliest_Time_to_Finish_One_Task;

/// <seealso href="https://leetcode.com/contest/weekly-contest-467/problems/earliest-time-to-finish-one-task/submissions/1769958835/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EarliestTime(int[][] tasks) => tasks.Select(t => t[0] + t[1]).Min();
}
