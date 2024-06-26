using JetBrains.Annotations;

namespace LeetCode.Problems._3197_Find_the_Minimum_Area_to_Cover_All_Ones_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1297967261/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MinimumSum(int[][] grid)
    {
        const int impossible = 1000;
        const int notFound = -1;

        var topLeftOneDp = new DynamicProgramming<(int top, int left, int bottom, int right), (int topOne, int leftOne)>((key, recursiveFunc) =>
        {
            var (top, left, bottom, right) = key;

            if (top > bottom || left > right)
            {
                return (topOne: notFound, leftOne: notFound);
            }

            for (var column = left; column <= right; column++)
            {
                if (grid[top][column] == 1)
                {
                    return (top, column);
                }
            }

            return recursiveFunc((top + 1, left, bottom, right));
        });

        var minimumSumDp = new DynamicProgramming<(int top, int left, int bottom, int right, int rectangleCount), int>(
            (key, recursiveFunc) =>
            {
                var (top, left, bottom, right, rectangleCount) = key;

                if (top > bottom || left > right)
                {
                    return rectangleCount == 0 ? 0 : impossible;
                }

                var totalArea = (bottom - top + 1) * (right - left + 1);
                if (totalArea < rectangleCount)
                {
                    return impossible;
                }

                var (topOne, leftOne) = topLeftOneDp.GetOrCalculate((top, left, bottom, right));

                if (topOne == notFound)
                {
                    return rectangleCount;
                }

                if (rectangleCount == 0)
                {
                    return impossible;
                }

                var ans = impossible;

                for (var row = topOne; row <= bottom; row++)
                {
                    for (var column = leftOne; column <= right; column++)
                    {
                        var area = (row - topOne + 1) * (column - leftOne + 1);

                        var uncoveredRectangleSets = new[]
                        {
                            new[]
                            {
                                (top: topOne, left, bottom: row, right: leftOne - 1),
                                (top: topOne, left: column + 1, bottom: row, right),
                                (top: row + 1, left, bottom, right)
                            },
                            new[]
                            {
                                (top: topOne, left, bottom, right: leftOne - 1),
                                (top: topOne, left: column + 1, bottom: row, right),
                                (top: row + 1, left: leftOne, bottom, right)
                            },
                            new[]
                            {
                                (top: topOne, left, bottom: row, right: leftOne - 1),
                                (top: topOne, left: column + 1, bottom, right),
                                (top: row + 1, left, bottom, right: column)
                            },
                            new[]
                            {
                                (top: topOne, left, bottom, right: leftOne - 1),
                                (top: topOne, left: column + 1, bottom, right),
                                (top: row + 1, left: leftOne, bottom, right: column)
                            }
                        };

                        const int uncoveredRectanglesCount = 3;
                        var counts = new int[uncoveredRectanglesCount];

                        foreach (var uncoveredRectangles in uncoveredRectangleSets)
                        {
                            for (counts[0] = 0; counts[0] < rectangleCount; counts[0]++)
                            {
                                for (counts[1] = 0; counts[1] < rectangleCount - counts[0]; counts[1]++)
                                {
                                    counts[2] = rectangleCount - 1 - counts[0] - counts[1];

                                    var result = area;

                                    for (var i = 0; i < uncoveredRectanglesCount; i++)
                                    {
                                        var otherRectangle = uncoveredRectangles[i];
                                        result += recursiveFunc((otherRectangle.top, otherRectangle.left,
                                            otherRectangle.bottom, otherRectangle.right, counts[i]));
                                    }

                                    ans = Math.Min(ans, result);
                                }
                            }
                        }
                    }
                }

                return ans;
            });

        var m = grid.Length;
        var n = grid[0].Length;
        return minimumSumDp.GetOrCalculate((0, 0, m - 1, n - 1, 3));
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
