using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2572_Count_the_Number_of_Square_Free_Subsets;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-333/submissions/detail/900721283/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int SquareFreeSubsets(int[] nums)
    {
        const int modulo = 1_000_000_007;

        var n = nums.Length;
        var result = BigInteger.ModPow(2, n, modulo) - 1;

        var primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        var primeSquares = primes.Select(prime => prime * prime).ToArray();

        for (var i = 0; i < n; i++)
        {
            if (primeSquares.Any(primeSquare => nums[i] % primeSquare == 0))
            {
                result = (result - BigInteger.ModPow(2, n - i - 1, modulo)) % modulo;
                result = (result + modulo) % modulo;
                continue;
            }

            for (var j = i + 1; j < n; j++)
            {
                if (primeSquares.All(primeSquare => nums[i] * nums[j] % primeSquare != 0))
                {
                    continue;
                }

                result = (result - BigInteger.ModPow(2, n - j - 1, modulo)) % modulo;
                result = (result + modulo) % modulo;
            }
        }

        return (int) result;
    }
}
