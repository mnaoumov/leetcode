namespace LeetCode.Problems._1615_Maximal_Network_Rank;

/// <summary>
/// https://leetcode.com/submissions/detail/906216723/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximalNetworkRank(int n, int[][] roads)
    {
        var neighborsMap = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var road in roads)
        {
            neighborsMap[road[0]].Add(road[1]);
            neighborsMap[road[1]].Add(road[0]);
        }

        var orderedEntries = neighborsMap.Select((neighbors, index) => (neighbors, index)).OrderByDescending(x => x.neighbors.Count).ToArray();

        var greatestCount = orderedEntries[0].neighbors.Count;
        var secondGreatestCount = orderedEntries[1].neighbors.Count;

        if (greatestCount > secondGreatestCount)
        {
            for (var i = 1; i < orderedEntries.Length; i++)
            {
                var neighbors = orderedEntries[i].neighbors;

                if (neighbors.Count < secondGreatestCount)
                {
                    break;
                }

                if (!neighbors.Contains(orderedEntries[0].index))
                {
                    return greatestCount + secondGreatestCount;
                }
            }

            return greatestCount + secondGreatestCount - 1;
        }

        for (var i = 0; i < orderedEntries.Length; i++)
        {
            if (orderedEntries[i].neighbors.Count < greatestCount)
            {
                break;
            }

            for (var j = i + 1; j < orderedEntries.Length; j++)
            {
                if (orderedEntries[j].neighbors.Count < greatestCount)
                {
                    break;
                }

                if (!orderedEntries[j].neighbors.Contains(orderedEntries[i].index))
                {
                    return 2 * greatestCount;
                }
            }
        }

        return 2 * greatestCount - 1;
    }
}
