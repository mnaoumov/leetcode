namespace LeetCode.Problems._0370_Range_Addition;

/// <summary>
/// https://leetcode.com/problems/range-addition/submissions/1842115387/?envType=weekly-question
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetModifiedArray(int length, int[][] updates)
    {
        var diffs = new int[length + 1];

        foreach (var update in updates)
        {
            var startIdx = update[0];
            var endIdx = update[1];
            var inc = update[2];

            diffs[startIdx] += inc;
            diffs[endIdx + 1] -= inc;
        }

        var ans = new int[length];

        for (var i = 0; i < length; i++)
        {
            ans[i] = (i == 0 ? 0 : ans[i - 1]) + diffs[i];
        }

        return ans;
    }
}
