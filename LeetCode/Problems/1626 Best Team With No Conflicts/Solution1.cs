namespace LeetCode.Problems._1626_Best_Team_With_No_Conflicts;

/// <summary>
/// https://leetcode.com/submissions/detail/888548269/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int BestTeamScore(int[] scores, int[] ages)
    {
        var players = scores.Zip(ages, (score, age) => new Player(score, age)).OrderBy(p => p.Age).ThenBy(p => p.Score)
            .ToArray();
        var dp = new DynamicProgramming<(int index, int minScore), int>((key, recursiveFunc) =>
        {
            var (index, minScore) = key;

            if (index == players.Length)
            {
                return 0;
            }

            var result = recursiveFunc((index + 1, minScore));

            var player = players[index];

            if (player.Score >= minScore)
            {
                result = Math.Max(result, player.Score + recursiveFunc((index + 1, player.Score)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, 0));
    }

    private record Player(int Score, int Age);

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
