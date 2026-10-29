namespace LeetCode.Problems._3680_Generate_Schedule;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int[][] GenerateSchedule(int n)
    {
        var dp = new DynamicProgramming<(string gamesStr, Game lastGame), Game[]>((key, recursiveFunc) =>
        {
            var (gamesStr, lastGame) = key;
            var games = Game.ParseArray(gamesStr);

            foreach (var game in games)
            {
                if (game.HasCommonTeams(lastGame))
                {
                    continue;
                }

                var nextGames = games.Where(g => g != game).ToArray();

                if (nextGames.Length == 0)
                {
                    return new[] { game };
                }

                var nextGamesStr = Game.ToArrayString(nextGames);
                var nextResult = recursiveFunc((nextGamesStr, game));
                if (nextResult.Length != 0)
                {
                    return nextResult.Prepend(game).ToArray();
                }
            }

            return Array.Empty<Game>();
        });

        var allGames = new List<Game>();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                allGames.Add(new Game(i, j));
            }
        }

        var gamesSchedule = dp.GetOrCalculate((Game.ToArrayString(allGames), new Game(-1, -1)));
        return gamesSchedule.Select(g => new[] { g.Home, g.Away }).ToArray();
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

    private record Game(int Home, int Away)
    {
        private const char GameSeparator = ':';
        private const char ArraySeparator = ',';
        public override string ToString() => $"{Home}{GameSeparator}{Away}";

        private static Game Parse(string str)
        {
            var arr = str.Split(GameSeparator).Select(int.Parse).ToArray();
            return new Game(arr[0], arr[1]);
        }

        public static Game[] ParseArray(string str) => str.Split(ArraySeparator).Select(Parse).ToArray();

        public static string ToArrayString(IEnumerable<Game> games) =>
            string.Join(ArraySeparator, games.Select(g => g.ToString()));

        public bool HasCommonTeams(Game game) => Home == game.Home || Home == game.Away || Away == game.Home || Away == game.Away;
    }
}
