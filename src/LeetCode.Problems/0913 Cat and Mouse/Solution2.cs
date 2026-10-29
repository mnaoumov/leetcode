namespace LeetCode.Problems._0913_Cat_and_Mouse;

/// <summary>
/// https://leetcode.com/submissions/detail/970576221/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int CatMouseGame(int[][] graph)
    {
        const int mouseWin = 1;
        const int catWin = 2;
        const int draw = 0;

        var processing = new HashSet<(int mouse, int cat, bool isMouseMove)>();

        var dp = new DynamicProgramming<(int mouse, int cat, bool isMouseMove), int>((key, recursiveFunc) =>
        {
            processing.Add(key);
            var ans = Calculate();
            processing.Remove(key);
            return ans;

            int Calculate()
            {
                var (mouse, cat, isMouseMove) = key;

                if (cat == mouse)
                {
                    return catWin;
                }

                if (mouse == 0)
                {
                    return mouseWin;
                }

                var nextKeys = isMouseMove
                    ? graph[mouse].Select(nextMouse => (nextMouse, cat, false))
                    : graph[cat].Except(new[] { 0 }).Select(nextCat => (mouse, nextCat, true));
                var desiredWin = isMouseMove ? mouseWin : catWin;
                var lose = isMouseMove ? catWin : mouseWin;

                var hasDraw = false;

                foreach (var nextKey in nextKeys)
                {
                    if (processing.Contains(nextKey))
                    {
                        hasDraw = true;
                        continue;
                    }

                    var result = recursiveFunc(nextKey);

                    if (result == desiredWin)
                    {
                        return desiredWin;
                    }

                    if (result == draw)
                    {
                        hasDraw = true;
                    }
                }

                return hasDraw ? draw : lose;
            }
        });

        return dp.GetOrCalculate((1, 2, true));
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
