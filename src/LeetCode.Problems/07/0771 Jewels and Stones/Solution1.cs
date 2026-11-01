namespace LeetCode.Problems._0771_Jewels_and_Stones;

/// <seealso href="https://leetcode.com/submissions/detail/856865137/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelsSet = jewels.ToHashSet();
        return stones.Count(jewelsSet.Contains);
    }
}
