namespace LeetCode.Problems._3919_Minimum_Cost_to_Move_Between_Indices;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        var n = nums.Length;

        var closest = new int[n];
        closest[0] = 1;
        closest[n - 1] = n - 2;

        for (var i = 1; i < n - 1; i++)
        {
            var diff1 = nums[i] - nums[i - 1];
            var diff2 = nums[i + 1] - nums[i];
            closest[i] = diff2 < diff1 ? i + 1 : i - 1;
        }

        var distances = new Dictionary<(int l, int r), int>();

        return queries.Select(arr => GetDistance(arr[0], arr[1])).ToArray();

        int GetDistance(int l, int r)
        {
            if (!distances.ContainsKey((l, r)))
            {
                distances[(l, r)] = CalculateDistance(l, r);
            }

            return distances[(l, r)];
        }

        int CalculateDistance(int l, int r)
        {
            if (l == r)
            {
                return 0;
            }

            if (r == closest[l])
            {
                return 1;
            }

            var val = Math.Abs(nums[r] - nums[l]);

            for (var m = 0; m < n; m++)
            {
                if (distances.TryGetValue((l, m), out var dist1) && distances.TryGetValue((m, r), out var dist2))
                {
                    val = Math.Min(val, dist1 + dist2);
                }
            }

        }
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
