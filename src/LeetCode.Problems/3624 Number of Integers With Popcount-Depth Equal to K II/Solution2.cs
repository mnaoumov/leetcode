namespace LeetCode.Problems._3624_Number_of_Integers_With_Popcount_Depth_Equal_to_K_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-459/problems/number-of-integers-with-popcount-depth-equal-to-k-ii/submissions/1704234145/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] PopcountDepth(long[] nums, long[][] queries)
    {
        const int maxK = 5;

        var popCountIndices = Enumerable.Range(0, maxK + 1).Select(_ => new SortedSet<int>()).ToArray();

        var popcountDp = new DynamicProgramming<long, int>((num, recursiveFunc) =>
        {
            if (num == 0)
            {
                return 0;
            }

            return (int) (num & 1) + recursiveFunc(num >>> 1);
        });

        var popcountDepthDp = new DynamicProgramming<long, int>((num, recursiveFunc) =>
        {
            if (num == 1)
            {
                return 0;
            }

            return 1 + recursiveFunc(popcountDp.GetOrCalculate(num));
        });

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            var popcountDepth = popcountDepthDp.GetOrCalculate(num);

            if (popcountDepth <= maxK)
            {
                popCountIndices[popcountDepth].Add(i);
            }
        }

        var answers = new List<int>();

        foreach (var query in queries)
        {
            switch (query[0])
            {
                case 1:
                {
                    var l = (int) query[1];
                    var r = (int) query[2];
                    var k = (int) query[3];

                    var answer = popCountIndices[k].GetViewBetween(l, r).Count;
                    answers.Add(answer);
                    break;
                }
                case 2:
                {
                    var idx = (int) query[1];
                    var val = query[2];
                    var num = nums[idx];
                    var oldPopcountDepth = popcountDepthDp.GetOrCalculate(num);
                    if (oldPopcountDepth <= maxK)
                    {
                        popCountIndices[oldPopcountDepth].Remove(idx);
                    }

                    nums[idx] = val;
                    var newPopcountDepth = popcountDepthDp.GetOrCalculate(val);
                    if (newPopcountDepth <= maxK)
                    {
                        popCountIndices[newPopcountDepth].Add(idx);
                    }

                    break;
                }
            }
        }

        return answers.ToArray();
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
