namespace LeetCode.Problems._3872_Longest_Arithmetic_Sequence_After_Changing_At_Most_One_Element;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-493/problems/longest-arithmetic-sequence-after-changing-at-most-one-element/submissions/1948684161/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestArithmetic(int[] nums)
    {
        var n = nums.Length;
        var diffs = new int[n - 1];

        for (var i = 0; i < n - 1; i++)
        {
            diffs[i] = nums[i + 1] - nums[i];
        }

        const int anyDiff = int.MinValue;

        var dp = new DynamicProgramming<(int index, int diff, bool canSwap), (int maxSequenceLengthStartingAtIndex, int maxSequenceLengthStartingLater)>((key, getOrCalculate) =>
        {
            var (index, diff, canSwap) = key;

            if (index == n - 1)
            {
                return (maxSequenceLengthStartingAtIndex: 0, maxSequenceLengthStartingLater: 0);
            }

            var maxSequenceLengthStartingLater = 1;

            var nextResult = getOrCalculate((index + 1, anyDiff, canSwap));
            maxSequenceLengthStartingLater =
                Math.Max(maxSequenceLengthStartingLater, nextResult.maxSequenceLengthStartingLater);
            var maxSequenceLengthStartingAtIndex = 0;

            var currentDiff = diffs[index];

            if (diff == anyDiff || diff == currentDiff)
            {
                nextResult = getOrCalculate((index + 1, currentDiff, canSwap));
                maxSequenceLengthStartingAtIndex = Math.Max(maxSequenceLengthStartingAtIndex,
                    1 + nextResult.maxSequenceLengthStartingAtIndex);

                if (index < n - 2 && canSwap)
                {
                    var nextDiff = diffs[index + 1];

                    nextResult = getOrCalculate((index + 1, nextDiff, false));
                    maxSequenceLengthStartingAtIndex = Math.Max(maxSequenceLengthStartingAtIndex,
                        1 + nextResult.maxSequenceLengthStartingAtIndex);
                }
            }
            else if (canSwap)
            {
                if (index < n - 2 && diffs[index + 1] + diffs[index] == 2 * diff)
                {
                    nextResult = getOrCalculate((index + 2, diff, false));
                    maxSequenceLengthStartingAtIndex = Math.Max(maxSequenceLengthStartingAtIndex,
                        2 + nextResult.maxSequenceLengthStartingAtIndex);
                }
                else
                {
                    maxSequenceLengthStartingAtIndex = 1;
                }
            }

            maxSequenceLengthStartingLater = Math.Max(maxSequenceLengthStartingLater, maxSequenceLengthStartingAtIndex);
            return (maxSequenceLengthStartingAtIndex, maxSequenceLengthStartingLater);
        });

        return dp.GetOrCalculate((0, anyDiff, true)).maxSequenceLengthStartingLater + 1;
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }

}
