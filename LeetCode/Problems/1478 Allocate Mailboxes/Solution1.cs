namespace LeetCode.Problems._1478_Allocate_Mailboxes;

/// <summary>
/// https://leetcode.com/submissions/detail/949966080/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDistance(int[] houses, int k)
    {
        Array.Sort(houses);

        var dp = new DynamicProgramming<(int fromIndex, int toIndex, int mailboxesCount), int>((key, recursiveFunc) =>
        {
            var (fromIndex, toIndex, mailboxCount) = key;

            if (fromIndex > toIndex)
            {
                return 0;
            }

            if (mailboxCount == 1)
            {
                var medianIndex = fromIndex + (toIndex - fromIndex >> 1);

                return Enumerable.Range(fromIndex, toIndex - fromIndex + 1)
                    .Sum(index => Math.Abs(houses[index] - houses[medianIndex]));
            }

            var ans = int.MaxValue;

            for (var i = fromIndex; i <= toIndex; i++)
            {
                ans = Math.Min(ans,
                    recursiveFunc((fromIndex, i, 1)) + recursiveFunc((i + 1, toIndex, mailboxCount - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, houses.Length - 1, k));
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
