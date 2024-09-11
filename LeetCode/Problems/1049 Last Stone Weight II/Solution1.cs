namespace LeetCode.Problems._1049_Last_Stone_Weight_II;

/// <summary>
/// https://leetcode.com/submissions/detail/957515372/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LastStoneWeightII(int[] stones)
    {
        var diffs = new HashSet<int> { 0 };

        foreach (var stone in stones)
        {
            var nextDiffs = new HashSet<int>();

            foreach (var diff in diffs)
            {
                nextDiffs.Add(Math.Abs(diff - stone));
                nextDiffs.Add(Math.Abs(diff + stone));
            }

            diffs = nextDiffs;
        }

        return diffs.Min();
    }
}
