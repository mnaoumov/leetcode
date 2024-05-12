using JetBrains.Annotations;

namespace LeetCode.Problems._3013_Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1151743795/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinimumCost(int[] nums, int k, int dist)
    {
        const long impossible = long.MaxValue;
        const int unset = -1;

        var dp = new DynamicProgramming<(int index, int partsLeft, int secondPartIndex), long>((key, recursiveFunc) =>
        {
            var (index, partsLeft, secondPartIndex) = key;

            if (partsLeft == 0)
            {
                return 0;
            }

            if (partsLeft > nums.Length - index)
            {
                return impossible;
            }

            if (secondPartIndex == unset)
            {
                return Math.Min(recursiveFunc((index + 1, partsLeft, unset)),
                    nums[0] + recursiveFunc((index, partsLeft - 1, index)));
            }

            if (partsLeft == 1 && index > secondPartIndex + dist)
            {
                return impossible;
            }

            var startNewPartResult = recursiveFunc((index + 1, partsLeft - 1, secondPartIndex));
            var continueResult = recursiveFunc((index + 1, partsLeft, secondPartIndex));

            var ans = continueResult;

            if (startNewPartResult != impossible)
            {
                ans = Math.Min(ans, nums[index] + startNewPartResult);
            }

            return ans;
        });

        return dp.GetOrCalculate((1, k, unset));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}

