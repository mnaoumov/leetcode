using JetBrains.Annotations;

namespace LeetCode._1349_Maximum_Students_Taking_Exam;

/// <summary>
/// https://leetcode.com/submissions/detail/926914430/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxStudents(char[][] seats)
    {
        var m = seats.Length;
        var n = seats[0].Length;

        var dp = new DynamicProgramming<(int i, int j, int previousValuesMask), int>((key, recursiveFunc) =>
        {
            var (i, j, previousValuesMask) = key;

            if (i == m)
            {
                return 0;
            }

            var nextI = i;
            var nextJ = j + 1;

            if (nextJ == n)
            {
                nextI++;
                nextJ = 0;
            }

            var nextMask = (previousValuesMask & ~(1 << n)) << 1;
            var result = recursiveFunc((nextI, nextJ, nextMask));
            var visibleSeatOffsets = new[] { (0, -1), (-1, -1), (-1, 1) };

            if (seats[i][j] != '.')
            {
                return result;
            }

            foreach (var (di, dj) in visibleSeatOffsets)
            {
                var otherSeatI = i + di;
                var otherSeatJ = j + dj;

                if (otherSeatI < 0 || otherSeatJ < 0 || otherSeatI >= m || otherSeatJ >= n)
                {
                    continue;
                }

                if (seats[otherSeatI][otherSeatJ] != '.')
                {
                    continue;
                }

                var offsetIndex = -n * di - dj - 1;

                if ((previousValuesMask >> offsetIndex & 1) == 0)
                {
                    continue;
                }

                return result;
            }

            result = Math.Max(result, 1 + recursiveFunc((nextI, nextJ, nextMask | 1)));
            return result;
        });

        return dp.GetOrCalculate((0, 0, 0));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
