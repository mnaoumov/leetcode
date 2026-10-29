namespace LeetCode.Problems._2176_Count_Equal_and_Divisible_Pairs_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/count-equal-and-divisible-pairs-in-an-array/submissions/1609108100/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPairs(int[] nums, int k)
    {
        var ans = 0;
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (nums[i] == nums[j] && i * j % k == 0)
                {
                    ans++;
                }
            }
        }
        return ans;
    }
}
