using System.Numerics;

namespace LeetCode.Problems._2818_Apply_Operations_to_Maximize_Score;

/// <summary>
/// https://leetcode.com/problems/apply-operations-to-maximize-score/submissions/1590549663/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaximumScore(IList<int> nums, int k)
    {
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

        var n = nums.Count;
        var primeScores = new int[n];
        var primeScoresMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (!primeScoresMap.ContainsKey(num))
            {
                primeScoresMap[num] = PrimeScore(num);
            }

            primeScores[i] = primeScoresMap[num];
        }

        var stack = new Stack<int>();
        var left = new int[n];
        var right = new int[n];

        for (var i = 0; i < n; i++)
        {
            while (stack.Count > 0 && primeScores[stack.Peek()] < primeScores[i])
            {
                stack.Pop();
            }
            left[i] = stack.Count == 0 ? -1 : stack.Peek();
            stack.Push(i);
        }

        stack.Clear();

        for (var i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && primeScores[stack.Peek()] <= primeScores[i])
            {
                stack.Pop();
            }
            right[i] = stack.Count == 0 ? n : stack.Peek();
            stack.Push(i);
        }

        ModNumber ans = 1;

        var orderedIndices = Enumerable.Range(0, n)
            .OrderByDescending(index => nums[index])
            .ThenBy(index => index)
            .ToArray();

        var stepsLeft = k;

        foreach (var index in orderedIndices)
        {
            var count = Math.Min(stepsLeft, (index - left[index]) * (right[index] - index));
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
            var primeIndex = 0;
            var ans2 = 0;

            while (num > 1)
            {
                var prime = primes[primeIndex];

                if (num % prime == 0)
                {
                    while (num % prime == 0)
                    {
                        num /= prime;
                    }

                    ans2++;
                }

                primeIndex++;
            }

            return ans2;
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
