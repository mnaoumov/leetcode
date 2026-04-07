namespace LeetCode.Problems._3864_Minimum_Cost_to_Partition_a_Binary_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-492/problems/minimum-cost-to-partition-a-binary-string/submissions/1941416891/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinCost(string s, int encCost, int flatCost)
    {
        var n = s.Length;

        var sensitivePrefixCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            sensitivePrefixCounts[i + 1] = sensitivePrefixCounts[i] + (s[i] == '1' ? 1 : 0);
        }

        var dp = new DynamicProgramming<(int startIndex, int length), long>((key, getOrCalculate) =>
        {
            var (startIndex, length) = key;

            var sensitiveCount = sensitivePrefixCounts[startIndex + length] - sensitivePrefixCounts[startIndex];
            var ans = sensitiveCount == 0 ? flatCost : 1L * length * sensitiveCount * encCost;

            if (length % 2 != 0)
            {
                return ans;
            }

            var halfLength = length / 2;
            var splitCost = getOrCalculate((startIndex, halfLength)) + getOrCalculate((startIndex + halfLength, halfLength));
            ans = Math.Min(ans, splitCost);
            return ans;
        });

        return dp.GetOrCalculate((0, n));
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
