using JetBrains.Annotations;

namespace LeetCode._6234_Number_of_Subarrays_With_LCM_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842340777/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SubarrayLCM(int[] nums, int k)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (k % nums[i] != 0)
            {
                continue;
            }

            var gcm = 1;

            for (var j = i; j < nums.Length; j++)
            {
                if (k % nums[j] != 0)
                {
                    break;
                }

                gcm = Gcm(gcm, nums[j]);

                if (gcm == k)
                {
                    result++;
                }

                if (gcm > k)
                {
                    break;
                }
            }
        }

        return result;
    }

    private static int Gcm(int a, int b)
    {
        if (a < b)
        {
            (a, b) = (b, a);
        }

        return a / Gcd(a, b) * b;
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
