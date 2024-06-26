using JetBrains.Annotations;

namespace LeetCode.Problems._3197_Find_the_Minimum_Area_to_Cover_All_Ones_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1298308655/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MinimumSum(int[][] grid)
    {
        const int impossible = 1000;

        var onesWrapperDp = new DynamicProgramming<Rectangle, Rectangle>((rectangle, recursiveFunc) =>
        {
            if (!rectangle.IsValid)
            {
                return Rectangle.Wrong;
            }

            var isTopLeftCorner = grid[rectangle.Top][rectangle.Left] == 1;

            if (isTopLeftCorner && grid[rectangle.Bottom][rectangle.Right] == 1)
            {
                return rectangle;
            }

            var moveRight = recursiveFunc(rectangle with { Left = rectangle.Left + 1 });
            var moveDown = recursiveFunc(rectangle with { Top = rectangle.Top + 1 });

            var top = isTopLeftCorner ? rectangle.Top : Math.Min(moveRight.Top, moveDown.Top);
            var left = isTopLeftCorner ? rectangle.Left : Math.Min(moveRight.Left, moveDown.Left);
            var bottom = Math.Max(moveRight.Bottom, moveDown.Bottom);
            var right = Math.Max(moveRight.Right, moveDown.Right);

            // ReSharper disable once InvertIf
            if (!moveRight.IsValid && !moveDown.IsValid && isTopLeftCorner)
            {
                bottom = rectangle.Top;
                right = rectangle.Left;
            }

            return new Rectangle(top, left, bottom, right);
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

                rectangle = onesWrapperDp.GetOrCalculate(rectangle);

                if (!rectangle.IsValid)
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
                        var a = recursiveFunc((rectangle with { Right = column }, count));
                        var b = recursiveFunc((rectangle with { Left = column + 1 }, rectangleCount - count));
                        ans = Math.Min(ans, a + b);
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
        public static readonly Rectangle Wrong = new Rectangle(int.MaxValue, int.MaxValue, int.MinValue, int.MinValue);
    }
}
