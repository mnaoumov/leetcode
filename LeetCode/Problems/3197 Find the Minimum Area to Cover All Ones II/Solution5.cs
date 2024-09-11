using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3197_Find_the_Minimum_Area_to_Cover_All_Ones_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1298012404/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MinimumSum(int[][] grid)
    {
        const int impossible = 1000;
        const int notFound = 1000;

        var topLeftOneDp = new DynamicProgramming<Rectangle, (int topOne, int leftOne)>((rectangle, recursiveFunc) =>
        {
            if (!rectangle.IsValid)
            {
                return (topOne: notFound, leftOne: notFound);
            }

            if (grid[rectangle.Top][rectangle.Left] == 1)
            {
                return (rectangle.Top, rectangle.Left);
            }

            var x = recursiveFunc(rectangle with { Left = rectangle.Left + 1 });
            var y = recursiveFunc(rectangle with { Top = rectangle.Top + 1 });

            return (topOne: Math.Min(x.topOne, y.topOne), leftOne: Math.Min(x.leftOne, y.leftOne));
        });

        var minimumSumDp = new DynamicProgramming<(Rectangle rectangle, int rectangleCount), int>(
            (key, recursiveFunc) =>
            {
                var (rectangle, rectangleCount) = key;

                if (!rectangle.IsValid)
                {
                    return rectangleCount == 0 ? 0 : impossible;
                }

                if (rectangle.Area < rectangleCount)
                {
                    return impossible;
                }

                var (topOne, leftOne) = topLeftOneDp.GetOrCalculate(rectangle);

                if (topOne == notFound)
                {
                    return rectangleCount;
                }

                switch (rectangleCount)
                {
                    case 0:
                        return impossible;
                    case 1 when rectangle.Top != topOne:
                        return recursiveFunc((rectangle with { Top = topOne }, 1));
                    case 1 when rectangle.Left != leftOne:
                        return recursiveFunc((rectangle with { Left = leftOne }, 1));
                }

                var ans = rectangleCount == 1 ? rectangle.Area : impossible;

                for (var row = topOne; row < rectangle.Bottom; row++)
                {
                    for (var count = 0; count <= rectangleCount; count++)
                    {
                        ans = Math.Min(ans,
                            recursiveFunc((rectangle with { Top = topOne, Bottom = row }, count))
                            + recursiveFunc((rectangle with { Top = row + 1 }, rectangleCount - count)));
                    }
                }

                for (var column = leftOne; column < rectangle.Right; column++)
                {
                    for (var count = 0; count <= rectangleCount; count++)
                    {
                        ans = Math.Min(ans,
                            recursiveFunc((rectangle with { Left= leftOne, Right = column }, count))
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
        public bool IsValid => Top <= Bottom && Left <= Right;
        public int Area => (Bottom - Top + 1) * (Right - Left + 1);
    }
}
