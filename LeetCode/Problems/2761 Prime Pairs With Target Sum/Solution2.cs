using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2761_Prime_Pairs_With_Target_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984167724/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public IList<IList<int>> FindPrimePairs(int n)
    {
        if (n <= 3)
        {
            return new List<IList<int>>();
        }

        var primes = new SortedSet<int>(Enumerable.Range(2, n - 3));

        var lastPrime = 1;
        var lastToCheck = (int) Math.Sqrt(n - 2);

        while (true)
        {
            var p = primes.GetViewBetween(lastPrime + 1, n - 2).Min;

            if (p > lastToCheck)
            {
                break;
            }

            for (var k = 2 * p; k <= n - 2; k += p)
            {
                primes.Remove(k);
            }

            lastPrime = p;
        }

        return
            (from x in primes.TakeWhile(x => x <= n / 2)
             let y = n - x
             where primes.Contains(y)
             select new[] { x, y })
            .Cast<IList<int>>()
            .ToArray();
    }
}
