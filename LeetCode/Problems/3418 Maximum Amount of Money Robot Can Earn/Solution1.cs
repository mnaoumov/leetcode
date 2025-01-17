namespace LeetCode.Problems._3418_Maximum_Amount_of_Money_Robot_Can_Earn;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-432/submissions/detail/1505671439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumAmount(int[][] coins)
    {
        var m = coins.Length;
        var n = coins[0].Length;

        var dp = new DynamicProgramming<(int row, int column, int neutralizeCount), int>((key, recursiveFunc) =>
        {
            var (row, column, neutralizeCount) = key;

            var cellValue = coins[row][column];

            var moveOptions = new List<(int takeValue, int newNeutralizeCount)> { (cellValue, neutralizeCount) };
            if (cellValue < 0 && neutralizeCount > 0)
            {
                moveOptions.Add((0, neutralizeCount - 1));
            }

            var ans = int.MinValue;

            foreach (var (takeValue, newNeutralizeCount) in moveOptions)
            {
                var nextAns = int.MinValue;

                if (row + 1 < m)
                {
                    nextAns = Math.Max(nextAns, takeValue + recursiveFunc((row + 1, column, newNeutralizeCount)));
                }

                if (column + 1 < n)
                {
                    nextAns = Math.Max(nextAns, takeValue + recursiveFunc((row, column + 1, newNeutralizeCount)));
                }

                if (nextAns == int.MinValue)
                {
                    nextAns = takeValue;
                }

                ans = Math.Max(ans, nextAns);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 2));
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
