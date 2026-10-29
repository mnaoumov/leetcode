namespace LeetCode.Problems._3556_Sum_of_Largest_Prime_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-157/problems/sum-of-largest-prime-substrings/submissions/1643112032/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long SumOfLargestPrimes(string s)
    {
        var n = s.Length;
        var substrings = new HashSet<string>();
        var primes = new HashSet<long>();

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                var substring = s[i..j];
                if (!substrings.Add(substring))
                {
                    continue;
                }

                var num = long.Parse(substring);
                if (IsPrime(num))
                {
                    primes.Add(num);
                }
            }
        }

        return primes.OrderByDescending(x => x).Take(3).Sum();
    }

    private static bool IsPrime(long num)
    {
        if (num < 2)
        {
            return false;
        }

        for (var i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
