namespace LeetCode.Problems._3726_Remove_Zeros_in_Decimal_Representation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-473/problems/remove-zeros-in-decimal-representation/submissions/1811773222/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long RemoveZeros(long n)
    {
        var ans = 0L;
        var powerOfTen = 1L;

        while (n > 0)
        {
            var digit = n % 10;
            n /= 10;

            if (digit == 0)
            {
                continue;
            }

            ans += digit * powerOfTen;
            powerOfTen *= 10;
        }

        return ans;
    }
}
