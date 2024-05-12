using JetBrains.Annotations;

namespace LeetCode._2579_Count_Total_Number_of_Colored_Cells;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-99/submissions/detail/908910206/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long ColoredCells(int n) => 1 + 2L * n * (n - 1);
}
