using JetBrains.Annotations;

namespace LeetCode.Problems._2741_Special_Permutations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-350/submissions/detail/973703152/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SpecialPerm(int[] nums)
    {
        const int modulo = 1_000_000_007;

        var allIndicesMask = (1 << nums.Length) - 1;

        var dp = new DynamicProgramming<(int previousNum, int usedIndicesMask), int>((key, recursiveFunc) =>
        {
            var (previousNum, usedIndicesMask) = key;

            if (usedIndicesMask == allIndicesMask)
            {
                return 1;
            }

            var ans = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                if ((usedIndicesMask >> i & 1) == 1)
                {
                    continue;
                }

                var num = nums[i];

                if (previousNum % num == 0 || num % previousNum == 0)
                {
                    ans = ModSum(modulo, ans, recursiveFunc((num, usedIndicesMask | 1 << i)));
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((1, 0));
    }

    private static int ModSum(int modulo, IEnumerable<int> nums) => nums.Aggregate(0, (cur, num) => (cur + num) % modulo);
    private static int ModSum(int modulo, params int[] nums) => ModSum(modulo, nums.AsEnumerable());

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
