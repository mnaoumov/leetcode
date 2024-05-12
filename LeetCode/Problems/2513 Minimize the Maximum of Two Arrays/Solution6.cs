using JetBrains.Annotations;

namespace LeetCode.Problems._2513_Minimize_the_Maximum_of_Two_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/864935543/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MinimizeSet(int divisor1, int divisor2, int uniqueCnt1, int uniqueCnt2)
    {
        var gcm = Gcm(divisor1, divisor2);

        var min = (long) uniqueCnt1 + uniqueCnt2;
        var max = (long) ((min + 2) / (1 - 1d / divisor1 - 1d / divisor2 + 1d / gcm));

        while (max > min)
        {
            var mid = min + (max - min >> 1);

            if (CheckIsEnough(mid))
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }

            continue;

            bool CheckIsEnough(long n)
            {
                var dividend1Count = n / divisor1;
                var dividend2Count = n / divisor2;
                var dividendCommonCount = n / gcm;
                return Math.Max(0, uniqueCnt1 - dividend2Count + dividendCommonCount) +
                       Math.Max(0, uniqueCnt2 - dividend1Count + dividendCommonCount) <=
                       n - dividend1Count - dividend2Count + dividendCommonCount;

            }
        }

        return (int) min;
    }

    private static long Gcm(int a, int b) => a * (b / Gcd(a, b));

    private static long Gcd(int a, int b)
    {
        while (b > 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
    }
}
