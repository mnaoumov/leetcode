namespace LeetCode.Problems._3424_Minimum_Cost_to_Make_Arrays_Identical;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-148/problems/minimum-cost-to-make-arrays-identical/submissions/1512594205/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinCost(int[] arr, int[] brr, long k)
    {
        var costWithoutSwaps = GetCost(arr, brr);
        Array.Sort(arr);
        Array.Sort(brr);
        var constWithSwaps = k + GetCost(arr, brr);
        return Math.Min(costWithoutSwaps, constWithSwaps);
    }

    private static long GetCost(int[] arr, int[] brr) => arr.Zip(brr, (a, b) => (a, b)).Select(x => 0L + Math.Abs(x.a - x.b)).Sum();
}
