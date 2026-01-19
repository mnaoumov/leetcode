namespace LeetCode.Problems._3796_Find_Maximum_Value_in_a_Constrained_Sequence;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-173/problems/find-maximum-value-in-a-constrained-sequence/submissions/1873257061/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMaxVal(int n, int[][] restrictions, int[] diff)
    {
        var a = new int[n];

        var restrictionsMap = new Dictionary<int, int>();

        foreach (var arr in restrictions)
        {
            var idx = arr[0];
            var maxVal = arr[1];
            restrictionsMap[idx] = maxVal;
        }

        for (var i = 1; i < n; i++)
        {
            var maxVal = restrictionsMap.GetValueOrDefault(i, int.MaxValue);
            a[i] = Math.Min(a[i - 1] + diff[i - 1], maxVal);
        }

        for (var i = n - 2; i >= 0; i--)
        {
            a[i] = Math.Min(a[i], a[i + 1] + diff[i]);
        }

        return a.Max();
    }
}
