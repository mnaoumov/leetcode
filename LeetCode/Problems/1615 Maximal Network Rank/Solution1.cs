using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1615_Maximal_Network_Rank;

/// <summary>
/// https://leetcode.com/submissions/detail/906211431/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
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

        var secondGreatestCount = orderedEntries[1].neighbors.Count;
        var entriesWithSecondGreatestCount = orderedEntries.Skip(1).TakeWhile(x => x.neighbors.Count == secondGreatestCount);

        return orderedEntries[0].neighbors.Count + secondGreatestCount -
               (entriesWithSecondGreatestCount.All(x => orderedEntries[0].neighbors.Contains(x.index)) ? 1 : 0);
    }
}
