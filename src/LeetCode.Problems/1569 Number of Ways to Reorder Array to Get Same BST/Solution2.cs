namespace LeetCode.Problems._1569_Number_of_Ways_to_Reorder_Array_to_Get_Same_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/972346074/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumOfWays(int[] nums)
    {
        const int modulo = 1_000_000_007;

        // ReSharper disable once RedundantAssignment
        var chooseDp = new DynamicProgramming<(int n, int k), int>((key, recursiveFunc) =>
        {
            var (n, k) = key;

            if (k == 0)
            {
                return 1;
            }

            if (n == 0)
            {
                return 0;
            }

            return (recursiveFunc((n - 1, k)) + recursiveFunc((n - 1, k - 1))) % modulo;
        });

        return PossiblePermutations(nums) - 1;

        int PossiblePermutations(IReadOnlyList<int> arr)
        {
            if (arr.Count == 0)
            {
                return 1;
            }

            var root = arr[0];
            var smaller = arr.Where(num => num < root).ToArray();
            var greater = arr.Where(num => num > root).ToArray();

            return Multiply(
                PossiblePermutations(smaller),
                PossiblePermutations(greater),
                chooseDp.GetOrCalculate((arr.Count - 1, smaller.Length))
            );
        }

        static int Multiply(params int[] arr) => arr.Aggregate((curr, num) => (int) (1L * curr * num % modulo));
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
