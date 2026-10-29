namespace LeetCode.Problems._3345_Smallest_Divisible_Digit_Product_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-143/submissions/detail/1447669457/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestNumber(int n, int t)
    {
        var ans = n;

        while (true)
        {
            var digits = GetDigits(ans);
            var prod = digits.Aggregate(1, (current, digit) => current * digit);
            if (prod % t == 0)
            {
                return ans;
            }

            ans++;
        }
    }

    private static IEnumerable<int> GetDigits(int num)
    {
        if (num == 0)
        {
            return new List<int> { 0 };
        }

        var ans = new List<int>();
        while (num > 0)
        {
            ans.Insert(0, num % 10);
            num /= 10;
        }
        return ans;
    }
}
