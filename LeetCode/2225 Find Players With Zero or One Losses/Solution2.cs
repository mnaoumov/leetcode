using JetBrains.Annotations;

namespace LeetCode._2225_Find_Players_With_Zero_or_One_Losses;

/// <summary>
/// https://leetcode.com/submissions/detail/851228110/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

        var orderedKeys = loseCountsMap.Keys.OrderBy(x => x).ToArray();

        return new[] { FilterByCount(0), FilterByCount(1) };

        void CreateEntryIfMissing(int player)
        {
            if (!loseCountsMap.ContainsKey(player))
            {
                loseCountsMap[player] = 0;
            }
        }

        IList<int> FilterByCount(int count) => orderedKeys.Where(key => loseCountsMap[key] == count).ToArray();
    }
}