namespace LeetCode.Problems._3871_Count_Commas_in_Range_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-493/problems/count-commas-in-range-ii/submissions/1948542442/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountCommas(long n)
    {
        var ans = 0L;

        var min = 1L;
        var commasCount = 0;

        while (n >= min)
        {
            ans += 1L * (Math.Min(n, min * 1000 - 1) - min + 1) * commasCount;
            min *= 1000;
            commasCount++;
        }
        
        return ans;
    }
}
