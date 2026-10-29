namespace LeetCode.Problems._1390_Four_Divisors;

/// <summary>
/// https://leetcode.com/problems/four-divisors/submissions/1874726676/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumFourDivisors(int[] nums)
    {
        var maxChecked = 1;
        var primes = new SortedSet<int>();

        return nums.Select(Score).Sum();

        int Score(int num)
        {
            if (num < 2)
            {
                return 0;
            }

            for (var primeCandidate = maxChecked + 1; primeCandidate <= num; primeCandidate++)
            {
                var isPrime = primes.TakeWhile(prime => prime * prime <= primeCandidate).All(prime => primeCandidate % prime != 0);

                if (isPrime)
                {
                    primes.Add(primeCandidate);
                }
                maxChecked = primeCandidate;
            }

            var p = primes.TakeWhile(prime => prime * prime <= num).FirstOrDefault(prime => num % prime == 0);

            if (p == 0)
            {
                return 0;
            }

            if (num == p * p * p)
            {
                return 1 + p + p*p+ p * p * p;
            }

            var q = num / p;

            return p != q && primes.Contains(q) ? 1 + p + q + p * q : 0;
        }
    }
}
