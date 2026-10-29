namespace LeetCode.Problems._3906_Count_Good_Integers_on_a_Grid_Path;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-498/problems/count-good-integers-on-a-grid-path/submissions/1982287883/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountGoodIntegersOnPath(long l, long r, string directions) => CountGoodIntegersOnPath(r, directions) - CountGoodIntegersOnPath(l - 1, directions);

    private static long CountGoodIntegersOnPath(long r, string directions)
    {
        var nonDecreasingDigitIndices = new List<int> { 0 };
        const char down = 'D';
        const char right = 'R';

        foreach (var direction in directions)
        {
            switch (direction)
            {
                case down:
                    nonDecreasingDigitIndices.Add(nonDecreasingDigitIndices[^1] + 4);
                    break;
                case right:
                    nonDecreasingDigitIndices.Add(nonDecreasingDigitIndices[^1] + 1);
                    break;
                default:
                    throw new InvalidOperationException($"Wrong direction {direction}");
            }
        }

        var nonDecreasingDigitIndicesSet = nonDecreasingDigitIndices.ToHashSet();

        const int length = 16;
        var powersOfTen = new long[length];
        powersOfTen[0] = 1;

        for (var i = 1; i < 16; i++)
        {
            powersOfTen[i] = powersOfTen[i - 1] * 10;
        }


        var dp = new DynamicProgramming<(int index, long max, int minDigit), long>((key, getOrCalculate) =>
        {
            var (index, max, minDigit) = key;

            if (index == 16)
            {
                return 1;
            }

            var maxDigit = max / powersOfTen[length - 1 - index];

            var ans = 0L;

            var isDigitOnPath = nonDecreasingDigitIndicesSet.Contains(index);

            for (var digit = isDigitOnPath ? minDigit : 0; digit <= Math.Min(maxDigit, 9); digit++)
            {
                var nextMinDigit = isDigitOnPath ? digit : minDigit;
                var newMax = digit < maxDigit ? powersOfTen[length - 1 - index] - 1 : max - maxDigit * powersOfTen[length - 1 - index];
                ans += getOrCalculate((index + 1, newMax, nextMinDigit));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, r, 0));
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
