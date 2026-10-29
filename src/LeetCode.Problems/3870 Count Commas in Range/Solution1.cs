namespace LeetCode.Problems._3870_Count_Commas_in_Range;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-493/problems/count-commas-in-range/submissions/1948534001/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCommas(int n) => Math.Max(0, n - 999);
}
