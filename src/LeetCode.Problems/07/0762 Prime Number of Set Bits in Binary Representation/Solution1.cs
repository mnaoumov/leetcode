namespace LeetCode.Problems._0762_Prime_Number_of_Set_Bits_in_Binary_Representation;

/// <summary>
/// https://leetcode.com/problems/prime-number-of-set-bits-in-binary-representation/submissions/1926037666/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPrimeSetBits(int left, int right)
    {
        var primes = new HashSet<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 39, 31 };

        var ans = 0;

        for (var num = left; num <= right; num++)
        {
            if (primes.Contains(BitCount(num)))
            {
                ans++;
            }
        }

        return ans;
    }

    private static int BitCount(int num)
    {
        var ans = 0;

        while (num > 0)
        {
            ans += num & 1;
            num >>= 1;
        }
        return ans;
    }
}
