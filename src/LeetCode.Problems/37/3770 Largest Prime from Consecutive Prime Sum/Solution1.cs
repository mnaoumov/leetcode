namespace LeetCode.Problems._3770_Largest_Prime_from_Consecutive_Prime_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-479/problems/largest-prime-from-consecutive-prime-sum/submissions/1848839926/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LargestPrime(int n)
    {
        if (n < 2)
        {
            return 0;
        }

        var primes = new List<int>();
        var ans = 0;

        var num = 2;

        while (ans + num <= n)
        {
            var isPrime = primes.TakeWhile(prime => prime * prime <= num).All(prime => num % prime != 0);

            if (isPrime)
            {
                primes.Add(num);
                ans += num;
            }

            num++;
        }

        return ans;
    }
}
