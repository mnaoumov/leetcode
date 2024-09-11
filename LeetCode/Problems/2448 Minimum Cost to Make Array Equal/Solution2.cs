namespace LeetCode.Problems._2448_Minimum_Cost_to_Make_Array_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-316/submissions/detail/828339569/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinCost(int[] nums, int[] cost)
    {
        var sortedNumCost = nums.Zip(cost, (num, costValue) => (num, costValue)).OrderBy(p => p.num).ToArray();

        var totalCostValue = cost.Select(x => (long) x).Sum();

        var runningCostValue = 0L;

        for (var i = 0; i < sortedNumCost.Length; i++)
        {
            var (_, costValue) = sortedNumCost[i];
            runningCostValue += costValue;

            if (2 * runningCostValue < totalCostValue)
            {
                continue;
            }

            var result = GetChangeCost(sortedNumCost[i].num);
            if (i > 0)
            {
                result = Math.Min(result, GetChangeCost(sortedNumCost[i - 1].num));
            }

            return result;
        }

        return 0;

        long GetChangeCost(int target) => sortedNumCost.Select(p => (long) Math.Abs(p.num - target) * p.costValue).Sum();
    }
}
