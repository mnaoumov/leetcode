using JetBrains.Annotations;

namespace LeetCode._2561_Rearranging_Fruits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-331/submissions/detail/891746075/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var counts1 = basket1.GroupBy(cost => cost).ToDictionary(g => g.Key, g => g.Count());
        var counts2 = basket2.GroupBy(cost => cost).ToDictionary(g => g.Key, g => g.Count());
        var diffs = new List<(int cost, int diff)>();

        foreach (var cost in counts1.Keys.Union(counts2.Keys))
        {
            var diff = counts2.GetValueOrDefault(cost) - counts1.GetValueOrDefault(cost);

            if (diff == 0)
            {
                continue;
            }

            if (diff % 2 != 0)
            {
                return -1;
            }

            diffs.Add((cost, diff / 2));
        }

        diffs = diffs.OrderBy(x => x.diff).ToList();

        var result = 0L;

        var i = 0;
        var j = diffs.Count - 1;

        while (i < j)
        {
            var moves = Math.Min(-diffs[i].diff, diffs[j].diff);

            diffs[i] = (diffs[i].cost, diffs[i].diff + moves);
            diffs[j] = (diffs[j].cost, diffs[j].diff - moves);
            result += Math.Min(diffs[i].cost, diffs[j].cost) * moves;

            if (diffs[i].diff == 0)
            {
                i++;
            }

            if (diffs[j].diff == 0)
            {
                j--;
            }
        }

        return result;
    }
}
