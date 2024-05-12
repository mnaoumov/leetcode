using JetBrains.Annotations;

namespace LeetCode.Problems._2447_Number_of_Subarrays_With_GCD_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-316/submissions/detail/828299883/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SubarrayGCD(int[] nums, int k)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] % k != 0)
            {
                continue;
            }

            var gcd = nums[i];

            for (var j = i; j < nums.Length; j++)
            {
                if (nums[j] % k != 0)
                {
                    break;
                }

                gcd = GCD(gcd, nums[j]);

                if (gcd == k)
                {
                    result++;
                }
            }
        }

        return result;
    }

    private static int GCD(int n, int m)
    {
        while (m > 0)
        {
            (n, m) = (m, n % m);
        }

        return n;
    }
}
