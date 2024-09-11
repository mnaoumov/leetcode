namespace LeetCode.Problems._3197_Find_the_Minimum_Area_to_Cover_All_Ones_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1297991365/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MinimumSum(int[][] grid)
    {
        const int impossible = 1000;

        var hasOnesDp = new DynamicProgramming<Rectangle, bool>((rectangle, recursiveFunc) =>
        {
            if (rectangle.IsInvalid)
            {
                return false;
            }

            for (var column = rectangle.Left; column <= rectangle.Right; column++)
            {
                if (grid[rectangle.Top][column] == 1)
                {
                    return true;
                }
            }

            return recursiveFunc(rectangle with { Top = rectangle.Top + 1 });
        });

        var minimumSumDp = new DynamicProgramming<(Rectangle rectangle, int rectangleCount), int>(
            (key, recursiveFunc) =>
            {
                var (rectangle, rectangleCount) = key;

                if (rectangle.IsInvalid)
                {
                    return rectangleCount == 0 ? 0 : impossible;
                }

                if (rectangle.Area < rectangleCount)
                {
                    return impossible;
                }

                var hasOne = hasOnesDp.GetOrCalculate(rectangle);

                if (!hasOne)
                {
                    return rectangleCount;
                }

                if (rectangleCount == 0)
                {
                    return impossible;
                }

                var ans = rectangleCount == 1 ? rectangle.Area : impossible;

                for (var row = rectangle.Top; row < rectangle.Bottom; row++)
                {
                    for (var count = 0; count <= rectangleCount; count++)
                    {
                        ans = Math.Min(ans,
                            recursiveFunc((rectangle with { Bottom = row }, count))
                            + recursiveFunc((rectangle with { Top = row + 1 }, rectangleCount - count)));
                    }
                }

                for (var column = rectangle.Left; column < rectangle.Right; column++)
                {
                    for (var count = 0; count <= rectangleCount; count++)
                    {
                        ans = Math.Min(ans,
                            recursiveFunc((rectangle with { Right = column }, count))
                            + recursiveFunc((rectangle with { Left = column + 1 }, rectangleCount - count)));
                    }
                }

                return ans;
            });

        var m = grid.Length;
        var n = grid[0].Length;
        return minimumSumDp.GetOrCalculate((new Rectangle(0, 0, m - 1, n - 1), 3));
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

    private record Rectangle(int Top, int Left, int Bottom, int Right)
    {
        public bool IsInvalid => Top > Bottom || Left > Right;
        public int Area => (Bottom - Top + 1) * (Right - Left + 1);
    }
}
