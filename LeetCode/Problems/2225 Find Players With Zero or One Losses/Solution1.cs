using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._2225_Find_Players_With_Zero_or_One_Losses;

/// <summary>
/// https://leetcode.com/submissions/detail/850904243/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        var loseCountsMap = new Dictionary<int, int>();

        foreach (var match in matches)
        {
            CreateEntryIfMissing(match[0]);
            CreateEntryIfMissing(match[1]);
            loseCountsMap[match[1]]++;
        }

        var orderedKeys = loseCountsMap.Keys.OrderBy(x => x);

        return new[] { orderedKeys.Where(key => loseCountsMap[key] == 0).ToArray(), orderedKeys.Where(key => loseCountsMap[key] == 1).ToArray() };

        void CreateEntryIfMissing(int player)
        {
            if (!loseCountsMap.ContainsKey(player))
            {
                loseCountsMap[player] = 0;
            }
        }
    }
}
