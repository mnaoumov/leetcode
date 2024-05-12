using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._2818_Apply_Operations_to_Maximize_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-358/submissions/detail/1019826477/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumScore(IList<int> nums, int k)
    {
        var primeScores = new Dictionary<int, int>();

        var maxNum = nums.Max();
        var primes = new List<int>();

        for (var i = 2; i <= maxNum; i++)
        {
            var isPrime = primes.TakeWhile(p => p * p <= i).All(p => i % p != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        foreach (var num in nums)
        {
            if (primeScores.ContainsKey(num))
            {
                continue;
            }

            primeScores[num] = PrimeScore(num);
        }

        var n = nums.Count;

        ModNumber ans = 1;

        var orderedIndices = Enumerable.Range(0, n).OrderByDescending(index => nums[index])
            .ThenBy(index => index).ToArray();

        var stepsLeft = k;

        foreach (var index in orderedIndices)
        {
            var left = index;

            while (left >= 1 && primeScores[nums[left - 1]] < primeScores[nums[index]])
            {
                left--;
            }

            var right = index;
            while (right < n - 1 && primeScores[nums[right + 1]] <= primeScores[nums[index]])
            {
                right++;
            }

            var count = Math.Min((index - left + 1) * (right - index + 1), stepsLeft);

            ans *= BigInteger.ModPow(nums[index], count, ModNumber.Modulo);

            stepsLeft -= count;

            if (stepsLeft == 0)
            {
                break;
            }
        }

        return ans;

        int PrimeScore(int num)
        {
            var primeDivisors = new HashSet<int>();
            var primeIndex = 0;

            while (num > 1)
            {
                var prime = primes[primeIndex];

                if (num % prime != 0)
                {
                    primeIndex++;
                }
                else
                {
                    num /= prime;
                    primeDivisors.Add(prime);
                }
            }

            return primeDivisors.Count;
        }
    }

    private class ModNumber
    {
        public const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(BigInteger value) => new(value);
        public static implicit operator ModNumber(long value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
