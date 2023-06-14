using JetBrains.Annotations;

namespace LeetCode._0913_Cat_and_Mouse;

/// <summary>
/// https://leetcode.com/submissions/detail/970400183/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CatMouseGame(int[][] graph)
    {
        const int mouseWin = 1;
        const int catWin = 2;
        const int draw = 0;

        var dp = new DynamicProgramming<(int mouse, int cat, bool isMouseMove, string previousPositionsStr), int>((key, recursiveFunc) =>
        {
            var (mouse, cat, isMouseMove, previousPositionsStr) = key;

            if (mouse == 0)
            {
                return mouseWin;
            }

            if (cat == mouse)
            {
                return catWin;
            }

            var previousPositions = new SortedSet<(int mouse, int cat, bool isMouseMove)>(previousPositionsStr
                .Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s =>
                {
                    var parts = s.Split('-');
                    return (mouse: int.Parse(parts[0]), cat: int.Parse(parts[1]), isMouseMove: bool.Parse(parts[2]));
                }));

            if (!previousPositions.Add((mouse, cat, isMouseMove)))
            {
                return draw;
            }

            var nextPositionsStr = string.Join(',',
                previousPositions.Select(p => string.Join('-', p.mouse, p.cat, p.isMouseMove)));


            if (isMouseMove)
            {
                var hasDraw = false;

                foreach (var nextMouse in graph[mouse])
                {
                    var result = recursiveFunc((nextMouse, cat, false, nextPositionsStr));

                    switch (result)
                    {
                        case mouseWin:
                            return mouseWin;
                        case draw:
                            hasDraw = true;
                            break;
                    }
                }

                return hasDraw ? draw : catWin;
            }
            else
            {
                var hasDraw = false;

                foreach (var nextCat in graph[cat])
                {
                    if (nextCat == 0)
                    {
                        continue;
                    }

                    var result = recursiveFunc((mouse, nextCat, true, nextPositionsStr));

                    switch (result)
                    {
                        case catWin:
                            return catWin;
                        case draw:
                            hasDraw = true;
                            break;
                    }
                }

                return hasDraw ? draw : mouseWin;
            }
        });

        return dp.GetOrCalculate((1, 2, true, ""));
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
