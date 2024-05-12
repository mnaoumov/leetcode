using JetBrains.Annotations;

namespace LeetCode.Problems._2761_Prime_Pairs_With_Target_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/984927478/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public IList<IList<int>> FindPrimePairs(int n)
    {
        if (n <= 3)
        {
            return new List<IList<int>>();
        }

        var primes = Enumerable.Range(0, n - 1).Select(_ => true).ToArray();
        primes[0] = false;
        primes[1] = false;

        var m = (int) Math.Sqrt(n - 2);

        for (var i = 2; i <= m; i++)
        {
            if (!primes[i])
            {
                continue;
            }

            for (var j = i * i; j <= n - 2; j += i)
            {
                primes[j] = false;
            }
        }

        var ans = new List<IList<int>>();

        if (n % 2 == 1)
        {
            if (primes[n - 2])
            {
                ans.Add(new[] { 2, n - 2 });
            }

            return ans;
        }

        for (var x = 2; x <= n / 2; x++)
        {
            var y = n - x;

            if (primes[x] && primes[y])
            {
                ans.Add(new[] { x, y });
            }
        }

        return ans;
    }
}
