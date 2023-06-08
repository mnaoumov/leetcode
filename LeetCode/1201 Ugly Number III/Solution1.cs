using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._1201_Ugly_Number_III;

/// <summary>
/// https://leetcode.com/submissions/detail/966451793/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NthUglyNumber(int n, int a, int b, int c)
    {
        var low = 1;
        var high = 2_000_000_000;

        var ab = Lcm(a, b);
        var bc = Lcm(b, c);
        var ca = Lcm(c, a);
        var abc = Lcm(ab, c);

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var count = mid / a + mid / b + mid / c - mid / ab - mid / bc - mid / ca + mid / abc;

            if (count < n)
            {
                low = mid + 1;
            }
            else
            {
                if (count == n && (mid % a == 0 || mid % b == 0 || mid % c == 0))
                {
                    return mid;
                }

                high = mid - 1;
            }
        }

        throw new InvalidOperationException();
    }

    private static int Lcm(int a, int b) => a * b / (int) BigInteger.GreatestCommonDivisor(a, b);
}
