using JetBrains.Annotations;

namespace LeetCode.Problems._0204_Count_Primes;

/// <summary>
/// https://leetcode.com/submissions/detail/923266906/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountPrimes(int n)
    {
        var primes = new List<int>();

        var divisorUpperBound = 0;
        var limitToIncreaseUpperBound = 2;

        for (var i = 2; i < n; i++)
        {
            if (i == limitToIncreaseUpperBound)
            {
                divisorUpperBound++;
                limitToIncreaseUpperBound = (1 + divisorUpperBound) * (1 + divisorUpperBound);
            }

            var isPrime = primes.TakeWhile(prime => prime <= divisorUpperBound).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        return primes.Count;
    }
}
