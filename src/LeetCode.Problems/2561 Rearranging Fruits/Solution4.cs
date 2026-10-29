namespace LeetCode.Problems._2561_Rearranging_Fruits;

/// <summary>
/// https://leetcode.com/submissions/detail/895468989/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var minCost = basket1.Concat(basket2).Min();

        var counts1 = basket1.GroupBy(cost => cost).ToDictionary(g => g.Key, g => g.Count());
        var counts2 = basket2.GroupBy(cost => cost).ToDictionary(g => g.Key, g => g.Count());

        var costsToMoveFrom1 = new List<int>();
        var costsToMoveFrom2 = new List<int>();

        foreach (var cost in counts1.Keys.Union(counts2.Keys).OrderBy(cost => cost))
        {
            var diff = counts2.GetValueOrDefault(cost) - counts1.GetValueOrDefault(cost);

            if (diff % 2 != 0)
            {
                return -1;
            }

            switch (diff)
            {
                case 0:
                    continue;
                case > 0:
                    costsToMoveFrom2.AddRange(Enumerable.Repeat(cost, diff / 2));
                    break;
                default:
                    costsToMoveFrom1.AddRange(Enumerable.Repeat(cost, -diff / 2));
                    break;
            }
        }

        var result = 0L;

        var start1 = 0;
        var end1 = costsToMoveFrom1.Count - 1;
        var start2 = 0;
        var end2 = costsToMoveFrom2.Count - 1;

        while (start1 <= end1 && start2 <= end2)
        {
            var min1 = costsToMoveFrom1[start1];
            var max1 = costsToMoveFrom1[end1];
            var min2 = costsToMoveFrom2[start2];
            var max2 = costsToMoveFrom2[end2];

            var swapCost1 = Math.Min(min1, max2);
            var swapCost2 = Math.Min(min2, max1);
            var swapCostOrUsingMinCost = Math.Min(swapCost1, 2 * minCost);

            if (swapCost2 < swapCostOrUsingMinCost)
            {
                result += swapCost2;
                start2++;
                end1--;
            }
            else
            {
                result += swapCostOrUsingMinCost;
                start1++;
                end2--;
            }
        }

        return result;
    }
}
