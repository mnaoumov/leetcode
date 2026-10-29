namespace LeetCode.Problems._2761_Prime_Pairs_With_Target_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984196357/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
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

        if (n % 2 == 0)
        {
            return
                (from x in primesList.TakeWhile(x => x <= n / 2)
                    let y = n - x
                    where primesSet.Contains(y)
                    select new[] { x, y })
                .Cast<IList<int>>()
                .ToArray();
        }

        var ans = new List<IList<int>>();

        if (primesSet.Contains(n - 2))
        {
            ans.Add(new[] { 2, n - 2 });
        }

        return ans;
    }
}
