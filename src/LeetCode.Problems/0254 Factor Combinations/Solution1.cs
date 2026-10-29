namespace LeetCode.Problems._0254_Factor_Combinations;

/// <summary>
/// https://leetcode.com/submissions/detail/943589112/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> GetFactors(int n)
    {
        var dp = new DynamicProgramming<int, IList<IList<int>>>((num, recursiveFunc) =>
        {
            var ans = new List<IList<int>>();

            var keys = new HashSet<string>();

            for (var i = 2; i <= num - 1; i++)
            {
                if (num % i != 0)
                {
                    continue;
                }

                AddToAnswer(i, new[] { num / i });

                foreach (var list in recursiveFunc(num / i))
                {
                    AddToAnswer(i, list);
                }
            }

            return ans;

            void AddToAnswer(int i, IEnumerable<int> list)
            {
                var list2 = list.Append(i).OrderBy(x => x).ToArray();
                var key = string.Join(",", list2);

                if (!keys.Add(key))
                {
                    return;
                }

                ans.Add(list2);
            }
        });

        return dp.GetOrCalculate(n);
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
