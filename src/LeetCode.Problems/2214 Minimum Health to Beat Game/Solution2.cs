namespace LeetCode.Problems._2214_Minimum_Health_to_Beat_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/875867469/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinimumHealth(int[] damage, int armor)
    {
        var n = damage.Length;
        var sums = new long[n];

        for (var i = 0; i < n; i++)
        {
            sums[i] = (i > 0 ? sums[i - 1] : 0) + damage[i];
        }

        var result = long.MaxValue;

        for (var i = 0; i < n; i++)
        {
            result = Math.Min(result, 1 + Math.Max(i > 0 ? sums[i - 1] : 0, sums[n - 1] - Math.Min(damage[i], armor)));
        }

        return result;
    }
}
