namespace LeetCode.Problems._2436_Minimum_Split_Into_Subarrays_With_GCD_Greater_Than_One;

/// <summary>
/// https://leetcode.com/submissions/detail/882119315/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSplits(int[] nums)
    {
        var result = 1;
        var lastGcd = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            var nextGcd = Gcd(lastGcd, nums[i]);

            if (nextGcd != 1)
            {
                lastGcd = nextGcd;
            }
            else
            {
                result++;
                lastGcd = nums[i];
            }
        }

        return result;
    }

    private static int Gcd(int a, int b)
    {
        while (b > 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
