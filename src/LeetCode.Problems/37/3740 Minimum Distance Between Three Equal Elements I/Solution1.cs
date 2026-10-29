namespace LeetCode.Problems._3740_Minimum_Distance_Between_Three_Equal_Elements_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-475/problems/minimum-distance-between-three-equal-elements-i/submissions/1824621532/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumDistance(int[] nums)
    {
        var n = nums.Length;

        var ans = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (nums[j] != nums[i])
                {
                    continue;
                }

                for (var k = j + 1; k < n; k++)
                {
                    if (nums[k] != nums[i])
                    {
                        continue;
                    }

                    ans = Math.Min(ans, 2 * (k - i));
                    break;
                }
            }
        }

        if (ans == int.MaxValue)
        {
            ans = -1;
        }

        return ans;
    }
}
