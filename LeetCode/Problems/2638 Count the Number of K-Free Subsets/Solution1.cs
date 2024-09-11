namespace LeetCode.Problems._2638_Count_the_Number_of_K_Free_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/956291692/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long CountTheNumOfKFreeSubsets(int[] nums, int k)
    {
        Array.Sort(nums);
        var indicesMap = Enumerable.Range(0, nums.Length).ToDictionary(i => nums[i]);

        var dp = new DynamicProgramming<(int index, string skippedIndicesStr), long>((key, recursiveFunc) =>
        {
            var (index, skippedIndicesStr) = key;

            if (index == nums.Length)
            {
                return 1;
            }

            var ans = recursiveFunc((index + 1, skippedIndicesStr));

            var skippedIndices = skippedIndicesStr.Split(',', StringSplitOptions.RemoveEmptyEntries).ToHashSet();

            if (skippedIndices.Contains(index.ToString()))
            {
                return ans;
            }

            var nextSkippedIndicesStr = skippedIndicesStr;

            if (indicesMap.TryGetValue(nums[index] + k, out var skipIndex))
            {
                skippedIndices.Add(skipIndex.ToString());
                nextSkippedIndicesStr = string.Join(",", skippedIndices.OrderBy(x => x));
            }

            ans += recursiveFunc((index + 1, nextSkippedIndicesStr));
            return ans;
        });

        return dp.GetOrCalculate((0, ""));
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
