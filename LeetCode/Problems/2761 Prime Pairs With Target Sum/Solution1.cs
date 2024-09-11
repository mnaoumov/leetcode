namespace LeetCode.Problems._2761_Prime_Pairs_With_Target_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984154138/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindPrimePairs(int n)
    {
        var primes = new SortedSet<int>();

        for (var i = 2; i <= n - 2; i++)
        {
            var max = (int) Math.Sqrt(i);

            if (primes.TakeWhile(p => p <= max).All(p => i % p != 0))
            {
                primes.Add(i);
            }
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
