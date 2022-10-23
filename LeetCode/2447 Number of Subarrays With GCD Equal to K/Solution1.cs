using JetBrains.Annotations;

namespace LeetCode._2447_Number_of_Subarrays_With_GCD_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-316/submissions/detail/828292675/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int SubarrayGCD(int[] nums, int k)
    {
        var result = 0;

        var gcd = 0;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num % k != 0)
            {
                gcd = 0;
                continue;
            }

            gcd = gcd == 0 ? num : GCD(gcd, num);

            if (gcd == k)
            {
                result++;
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