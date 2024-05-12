using JetBrains.Annotations;

namespace LeetCode.Problems._1406_Stone_Game_III;

/// <summary>
/// https://leetcode.com/submissions/detail/921097166/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public string StoneGameIII(int[] stoneValue)
    {
        var dp = new DynamicProgramming<int, (int firstPlayerScore, int secondPlayerScore)>((index, recursiveFunc) =>
        {
            if (index == stoneValue.Length)
            {
                return (0, 0);
            }

            var takenStonesValue = 0;
            var firstPlayerScore = 0;
            var secondPlayerScore = 0;

            for (var j = index; j < Math.Min(index + 3, stoneValue.Length); j++)
            {
                takenStonesValue += stoneValue[j];
                var subResult = recursiveFunc(j + 1);
                var firstPlayerScoreCandidate = takenStonesValue + subResult.secondPlayerScore;

                if (firstPlayerScoreCandidate <= firstPlayerScore)
                {
                    continue;
                }

                firstPlayerScore = firstPlayerScoreCandidate;
                secondPlayerScore = subResult.firstPlayerScore;
            }

            return (firstPlayerScore, secondPlayerScore);
        });

        var bestScore = dp.GetOrCalculate(0);

        return bestScore.firstPlayerScore > bestScore.secondPlayerScore
            ? "Alice"
            : bestScore.firstPlayerScore < bestScore.secondPlayerScore
                ? "Bob"
                : "Tie";
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
