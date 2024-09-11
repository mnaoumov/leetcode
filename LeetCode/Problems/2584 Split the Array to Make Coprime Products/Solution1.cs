using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2584_Split_the_Array_to_Make_Coprime_Products;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-335/submissions/detail/909287588/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int FindValidSplit(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return -1;
        }

        var max = nums.Max();

        var primes = new SortedSet<int>();

        for (var i = 2; i <= max; i++)
        {
            var isPrime = primes.TakeWhile(p => p * p <= i).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        var primeFactors = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            var temp = num;

            foreach (var prime in primes.TakeWhile(_ => temp != 1))
            {
                if (primes.Contains(temp))
                {
                    primeFactors[i].Add(temp);
                    break;
                }

                while (temp % prime == 0)
                {
                    primeFactors[i].Add(prime);
                    temp /= prime;
                }
            }
        }

        var productFactors = primeFactors[0].ToHashSet();
        var resultFactors = primeFactors[0].ToHashSet();
        var result = 0;

        for (var i = 1; i <= n - 1; i++)
        {
            productFactors.UnionWith(primeFactors[i]);

            if (!resultFactors.Overlaps(primeFactors[i]))
            {
                continue;
            }

            result = i;
            resultFactors = productFactors.ToHashSet();

        }

        return result <= n - 2 ? result : -1;
    }
}
