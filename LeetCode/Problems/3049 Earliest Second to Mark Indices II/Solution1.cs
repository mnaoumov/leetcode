using JetBrains.Annotations;

namespace LeetCode.Problems._3049_Earliest_Second_to_Mark_Indices_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1185419357/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int EarliestSecondToMarkIndices(int[] nums, int[] changeIndices)
    {
        var n = nums.Length;
        var m = changeIndices.Length;
        const int impossible = -1;

        var dp = new DynamicProgramming<(int s, string markedStr, string countsStr), int>((key, recursiveFunc) =>
        {
            var (s, markedStr, countsStr) = key;
            var marked = new SortedSet<int>(ParseArray(markedStr));

            var counts = ParseCountsDictionary(countsStr);
            var decrementsSum = counts.Values.Sum();

            if (marked.Count == n)
            {
                return s - 1;
            }

            if (s == m + 1)
            {
                return impossible;
            }

            if (marked.Count + m - s + 1 - decrementsSum < n)
            {
                return impossible;
            }

            var ans = int.MaxValue;

            UpdateAns(recursiveFunc((s + 1, markedStr, countsStr)));

            var changeIndex = changeIndices[s - 1];

            if (!counts.ContainsKey(changeIndex) && marked.Add(changeIndex))
            {
                UpdateAns(recursiveFunc((s + 1, Join(marked), countsStr)));
                marked.Remove(changeIndex);
            }

            foreach (var index in counts.Keys.ToArray())
            {
                counts[index]--;

                UpdateAns(recursiveFunc((s + 1, markedStr, BuildCountsStr(counts))));

                counts[index]++;
            }


            if (ans == int.MaxValue)
            {
                ans = impossible;
            }

            return ans;

            void UpdateAns(int i)
            {
                if (i >= 0)
                {
                    ans = Math.Min(ans, i);
                }
            }
        });

        var numsDict = Enumerable.Range(0, n).ToDictionary(i => i + 1, i => nums[i]);
        return dp.GetOrCalculate((1, "", BuildCountsStr(numsDict)));

        int[] ParseArray(string arrayStr) =>
            arrayStr.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        string Join(IEnumerable<int> values) => string.Join(",", values);

        IDictionary<int, int> ParseCountsDictionary(string dictStr)
        {
            var dict = new Dictionary<int, int>();

            foreach (var pairStr in dictStr.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = pairStr.Split(":");
                dict[int.Parse(parts[0])] = int.Parse(parts[1]);
            }

            return dict;
        }

        string BuildCountsStr(IDictionary<int, int> counts) => string.Join(',',
            counts.Keys.OrderBy(i => i).Where(i => counts[i] > 0).Select(i => $"{i}:{counts[i]}"));
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
