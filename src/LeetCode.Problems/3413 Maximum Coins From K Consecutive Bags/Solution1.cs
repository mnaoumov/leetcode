namespace LeetCode.Problems._3413_Maximum_Coins_From_K_Consecutive_Bags;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution1 : ISolution
{
    public long MaximumCoins(int[][] coins, int k)
    {
        var ans = 0L;
        var n = coins.Length;
        var entries = coins.Select(coin => new Entry(coin[0], coin[1], coin[2])).OrderBy(e => e.Left).ToArray();

        var coinsCount = 0L;

        var maxIndex = entries[0].Left + k;
        int nextEntryIndex;

        for (nextEntryIndex = 0; nextEntryIndex < n; nextEntryIndex++)
        {
            var entry = entries[nextEntryIndex];

            if (entry.Left > maxIndex)
            {
                break;
            }

            coinsCount += 1L * entry.CoinsPerBag * (Math.Min(entry.Right, maxIndex) - entry.Left + 1);
        }

        ans = Math.Max(ans, coinsCount);

        for (var firstEntryIndex = 1; firstEntryIndex < n; firstEntryIndex++)
        {
            var entryToRemove = entries[firstEntryIndex - 1];
            coinsCount -= 1L * entryToRemove.CoinsPerBag * (Math.Min(entryToRemove.Right, maxIndex) - entryToRemove.Left + 1);

            var newMaxIndex = entries[firstEntryIndex].Left + k;
            var diff = newMaxIndex - maxIndex;

            var rest = entries[nextEntryIndex].Right - maxIndex;

            if (rest > 0)
            {
                coinsCount += 1L * entries[nextEntryIndex].CoinsPerBag * Math.Min(rest, diff);
            }

            while (true)
            {
                var entry = entries[nextEntryIndex];

                if (entry.Left > maxIndex)
                {
                    break;
                }

                coinsCount += 1L * entry.CoinsPerBag * (Math.Min(entry.Right, maxIndex) - entry.Left + 1);
                nextEntryIndex++;
            }
        }

        return ans;
    }

    private record Entry(int Left, int Right, int CoinsPerBag);
}
