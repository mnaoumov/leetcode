namespace LeetCode.Problems._1900_The_Earliest_and_Latest_Rounds_Where_Players_Compete;

/// <summary>
/// https://leetcode.com/problems/the-earliest-and-latest-rounds-where-players-compete/submissions/1694813136/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] EarliestAndLatest(int n, int firstPlayer, int secondPlayer)
    {
        var dp = new DynamicProgramming<(int playersCount, int firstPlayerIndex, int secondPlayerIndex), (int earliestLevel, int latestLevel)>((key, recursiveFunc) =>
        {
            var (playersCount, firstPlayerIndex, secondPlayerIndex) = key;

            if (firstPlayerIndex + secondPlayerIndex == playersCount + 1)
            {
                return (1, 1);
            }

            var earliestLevel2 = int.MaxValue;
            var latestLevel2 = int.MinValue;
            var nextCount = (playersCount + 1) / 2;

            for (var mask = 0; mask < 1 << nextCount; mask++)
            {
                if (playersCount % 2 == 1 && !IsValidMask(mask, nextCount))
                {
                    continue;
                }

                if (!IsValidMask(mask, firstPlayerIndex) || !IsValidMask(mask, secondPlayerIndex))
                {
                    continue;
                }

                var count = 0;
                var nextFirstPlayerIndex = 0;
                var nextSecondPlayerIndex = 0;

                for (var playerIndex = 1; playerIndex <= playersCount; playerIndex++)
                {
                    if (!IsValidMask(mask, playerIndex))
                    {
                        continue;
                    }

                    count++;

                    if (playerIndex == firstPlayerIndex)
                    {
                        nextFirstPlayerIndex = count;
                    }

                    if (playerIndex == secondPlayerIndex)
                    {
                        nextSecondPlayerIndex = count;
                    }
                }

                var result = recursiveFunc((nextCount, nextFirstPlayerIndex, nextSecondPlayerIndex));
                earliestLevel2 = Math.Min(earliestLevel2, result.earliestLevel + 1);
                latestLevel2 = Math.Max(latestLevel2, result.latestLevel + 1);
            }

            return (earliestLevel2, latestLevel2);

            bool IsValidMask(int mask, int playerIndex)
            {
                if (playerIndex <= nextCount)
                {
                    if ((mask & 1 << playerIndex - 1) == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if ((mask & 1 << playersCount - playerIndex) != 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        });

        var (earliestLevel, latestLevel) = dp.GetOrCalculate((n, firstPlayer, secondPlayer));
        return new[] { earliestLevel, latestLevel };
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
