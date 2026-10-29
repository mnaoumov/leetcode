namespace LeetCode.Problems._2366_Minimum_Replacements_to_Sort_the_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1035532407/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinimumReplacement(int[] nums)
    {
        var ans = 0L;
        var last = int.MaxValue;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num > last)
            {
                var k = (num + last - 1) / last;
                ans += k - 1;
                last = num / k;
            }
            else
            {
                last = num;
            }
        }

        return ans;
    }
}
