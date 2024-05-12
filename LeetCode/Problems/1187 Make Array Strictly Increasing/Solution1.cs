using JetBrains.Annotations;

namespace LeetCode.Problems._1187_Make_Array_Strictly_Increasing;

/// <summary>
/// https://leetcode.com/submissions/detail/973353104/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MakeArrayIncreasing(int[] arr1, int[] arr2)
    {
        const int impossible = int.MaxValue;

        arr2 = arr2.Distinct().OrderBy(num2 => num2).ToArray();

        var dp = new DynamicProgramming<(int index1, int previousValue), int>((key, recursiveFunc) =>
        {
            var (index1, previousValue) = key;

            if (index1 == arr1.Length)
            {
                return 0;
            }

            var ans = impossible;

            if (arr1[index1] > previousValue)
            {
                ans = recursiveFunc((index1 + 1, arr1[index1]));
            }

            var index2 = Array.BinarySearch(arr2, previousValue + 1);

            if (index2 < 0)
            {
                index2 = ~index2;
            }

            if (index2 == arr2.Length)
            {
                return ans;
            }

            var next = recursiveFunc((index1 + 1, arr2[index2]));

            if (next != impossible)
            {
                ans = Math.Min(ans, 1 + next);
            }

            return ans;
        });

        var ans2 = dp.GetOrCalculate((0, int.MinValue));
        return ans2 == impossible ? -1 : ans2;
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
