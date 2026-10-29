namespace LeetCode.Problems._3770_Largest_Prime_from_Consecutive_Prime_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-479/problems/largest-prime-from-consecutive-prime-sum/submissions/1848845366/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LargestPrime(int n)
    {
        if (n < 2)
        {
            return 0;
        }

        var primes = new List<int>();
        var ans = 0;
        var sum = 0;

        var num = 2;

        while (sum + num <= n)
        {
            var isPrime = primes.TakeWhile(prime => prime * prime <= num).All(prime => num % prime != 0);

            if (isPrime)
            {
                primes.Add(num);
                sum += num;

                isPrime = primes.TakeWhile(prime => prime * prime <= sum).All(prime => sum % prime != 0);
                if (isPrime)
                {
                    ans = sum;
                }
            }

            num++;
        }

        return ans;
    }
}
