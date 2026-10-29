namespace LeetCode.Problems._3556_Sum_of_Largest_Prime_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-157/problems/sum-of-largest-prime-substrings/submissions/1643154562/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long SumOfLargestPrimes(string s)
    {
        var n = s.Length;
        var substrings = new HashSet<string>();
        var primes = new HashSet<long>();

        var allPrimes = new SortedSet<long>();
        var maxChecked = 1L;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j <= n; j++)
            {
                var substring = s[i..j];
                if (!substrings.Add(substring))
                {
                    continue;
                }

                var subNum = long.Parse(substring);

                if (IsPrime(subNum))
                {
                    primes.Add(subNum);
                }
            }
        }

        return primes.OrderByDescending(x => x).Take(3).Sum();

        bool IsPrime(long m)
        {
            if (m <= maxChecked)
            {
                return allPrimes.Contains(m);
            }

            var maxCandidate = (int) Math.Sqrt(m);

            if (allPrimes.Where(p => p <= maxCandidate).Any(p => m % p == 0))
            {
                return false;
            }

            for (var p = maxChecked + 1; p <= maxCandidate; p++)
            {
                if (m % p == 0)
                {
                    return false;
                }

                if (allPrimes.Contains(p))
                {
                    maxChecked = p;
                    continue;
                }

                var maxCandidate2 = (int) Math.Sqrt(p);
                var isPrime = allPrimes.TakeWhile(q => q <= maxCandidate2).All(q => p % q != 0);
                maxChecked = p;

                if (isPrime)
                {
                    allPrimes.Add(p);
                }
            }

            allPrimes.Add(m);
            return true;
        }
    }
}
