namespace LeetCode.Problems._3572_Maximize_Y_Sum_by_Picking_a_Triplet_of_Distinct_X_Values;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-158/problems/maximize-ysum-by-picking-a-triplet-of-distinct-xvalues/submissions/1656669511/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSumDistinctTriplet(int[] x, int[] y)
    {
        var maxValuesMap = new Dictionary<int, int>();

        var n = x.Length;

        for (var i = 0; i < n; i++)
        {
            var value = x[i];
            maxValuesMap.TryAdd(x[i], int.MinValue);
            maxValuesMap[value] = Math.Max(maxValuesMap[value], y[i]);
        }

        if (maxValuesMap.Count < 3)
        {
            return -1;
        }

        return maxValuesMap.Values.OrderByDescending(v => v).Take(3).Sum();
    }
}
