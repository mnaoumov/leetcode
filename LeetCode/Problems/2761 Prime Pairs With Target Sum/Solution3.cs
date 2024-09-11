namespace LeetCode.Problems._2761_Prime_Pairs_With_Target_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984192044/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public IList<IList<int>> FindPrimePairs(int n)
    {
        var primesSet = new HashSet<int>();
        var primesList = new List<int>();

        for (var i = 2; i <= n - 2; i++)
        {
            var max = (int) Math.Sqrt(i);

            if (primesList.TakeWhile(p => p <= max).Any(p => i % p == 0))
            {
                continue;
            }

            primesList.Add(i);
            primesSet.Add(i);
        }

        return
            (from x in primesList.TakeWhile(x => x <= n / 2)
             let y = n - x
             where primesSet.Contains(y)
             select new[] { x, y })
            .Cast<IList<int>>()
            .ToArray();
    }
}
