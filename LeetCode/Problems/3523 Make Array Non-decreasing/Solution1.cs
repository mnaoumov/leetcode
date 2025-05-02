namespace LeetCode.Problems._3523_Make_Array_Non_decreasing;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-446/problems/make-array-non-decreasing/submissions/1612008975/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumPossibleSize(int[] nums)
    {
        var ans = 0;

        var last = int.MinValue;

        foreach (var num in nums)
        {
            if (num < last)
            {
                continue;
            }

            ans++;
            last = num;
        }

        return ans;
    }
}
