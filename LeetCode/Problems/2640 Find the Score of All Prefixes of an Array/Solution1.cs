using JetBrains.Annotations;

namespace LeetCode._2640_Find_the_Score_of_All_Prefixes_of_an_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934172482/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] FindPrefixScore(int[] nums)
    {
        var n = nums.Length;
        var result = new long[n];

        var max = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            max = Math.Max(max, nums[i]);
            result[i] = (i > 0 ? result[i - 1] : 0L) + nums[i] + max;
        }

        return result;
    }
}
