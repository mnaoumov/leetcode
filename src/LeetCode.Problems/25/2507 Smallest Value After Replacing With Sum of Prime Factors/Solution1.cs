namespace LeetCode.Problems._2507_Smallest_Value_After_Replacing_With_Sum_of_Prime_Factors;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-324/submissions/detail/861390389/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SmallestValue(int n)
    {
        while (true)
        {
            var m = SumOfPrimeFactors(n);

            if (m == n)
            {
                return n;
            }

            n = m;
        }
    }

    private static int SumOfPrimeFactors(int n)
    {
        var upperBound = (int) Math.Sqrt(n);

        for (var p = 2; p <= upperBound; p++)
        {
            if (n % p == 0)
            {
                return p + SumOfPrimeFactors(n / p);
            }
        }

        return n;
    }
}
