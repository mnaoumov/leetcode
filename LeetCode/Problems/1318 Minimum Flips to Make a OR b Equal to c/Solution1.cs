namespace LeetCode.Problems._1318_Minimum_Flips_to_Make_a_OR_b_Equal_to_c;

/// <summary>
/// https://leetcode.com/submissions/detail/965518213/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinFlips(int a, int b, int c)
    {
        var ans = 0;

        while (a > 0 || b > 0 || c > 0)
        {
            var aBit = GetBitAndShift(ref a);
            var bBit = GetBitAndShift(ref b);
            var cBit = GetBitAndShift(ref c);

            if ((aBit || bBit) == cBit)
            {
                continue;
            }

            if (!cBit && aBit && bBit)
            {
                ans += 2;
            }
            else
            {
                ans++;
            }
        }

        return ans;
    }

    private static bool GetBitAndShift(ref int n)
    {
        var bit = (n & 1) == 1;
        n >>= 1;
        return bit;
    }
}
