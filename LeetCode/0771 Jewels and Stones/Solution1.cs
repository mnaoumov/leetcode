using JetBrains.Annotations;

namespace LeetCode._0771_Jewels_and_Stones;

/// <summary>
/// https://leetcode.com/submissions/detail/856865137/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        var jewelsSet = jewels.ToHashSet();
        return stones.Count(jewelsSet.Contains);
    }
}
