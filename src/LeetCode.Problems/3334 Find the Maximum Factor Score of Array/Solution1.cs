namespace LeetCode.Problems._3334_Find_the_Maximum_Factor_Score_of_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-421/submissions/detail/1434779155/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxScore(int[] nums)
    {
        var n = nums.Length;
        var ans = 0L;

        for (var skipIndex = 0; skipIndex < n + 1; skipIndex++)
        {
            var gcd = 0L;
            var lcm = 1L;

            for (var i = 0; i < n; i++)
            {
                if (i == skipIndex)
                {
                    continue;
                }

                var num = nums[i];
                gcd = gcd == 0 ? num : Gcd(gcd, num);
                lcm = Lcm(lcm, num);
            }

            ans = Math.Max(ans, gcd * lcm);
        }

        return ans;
    }

    private static long Gcd(long a, long b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }

    private static long Lcm(long a, long b) => a * b / Gcd(a, b);
}
