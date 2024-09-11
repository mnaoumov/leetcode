namespace LeetCode.Problems._0650_2_Keys_Keyboard;

/// <summary>
/// https://leetcode.com/submissions/detail/945220286/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSteps(int n)
    {
        const int impossible = int.MaxValue;

        var dp = new DynamicProgramming<(int onScreenCount, int bufferCount), int>((key, recursiveFunc) =>
        {
            var (onScreenCount, bufferCount) = key;

            if (onScreenCount > n)
            {
                return impossible;
            }

            if (onScreenCount == n)
            {
                return 0;
            }

            var ans = impossible;

            if (onScreenCount != bufferCount)
            {
                var copyAllCount = onScreenCount != bufferCount
                    ? recursiveFunc((onScreenCount, onScreenCount))
                    : impossible;

                if (copyAllCount != impossible)
                {
                    ans = Math.Min(ans, copyAllCount + 1);
                }
            }

            if (bufferCount <= 0)
            {
                return ans;
            }

            var pasteCount = recursiveFunc((onScreenCount + bufferCount, bufferCount));

            if (pasteCount != impossible)
            {
                ans = Math.Min(ans, pasteCount + 1);
            }

            return ans;
        });

        return dp.GetOrCalculate((1, 0));
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
