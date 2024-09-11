namespace LeetCode.Problems._0376_Wiggle_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/930015467/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WiggleMaxLength(int[] nums)
    {
        var last = nums[0];
        var previousSign = 0;
        var result = 1;
        foreach (var num in nums)
        {
            var sign = Math.Sign(num - last);
            if (sign != 0)
            {
                if (previousSign != sign)
                {
                    result++;
                }
                previousSign = sign;
            }

            last = num;
        }
        return result;
    }
}
