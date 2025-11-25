namespace LeetCode.Problems._1015_Smallest_Integer_Divisible_by_K;

/// <summary>
/// https://leetcode.com/problems/binary-prefix-divisible-by-5/submissions/1838067745/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestRepunitDivByK(int k)
    {
        if (k % 2 == 0 || k % 5 == 0)
        {
            return -1;
        }

        var remainder = 1;
        var ans = 1;

        while (true)
        {
            if (remainder % k == 0)
            {
                return ans;
            }

            remainder = (remainder * 10 + 1) % k;
            ans++;
        }
    }
}
