using JetBrains.Annotations;

namespace LeetCode.Problems._1426_Counting_Elements;

/// <summary>
/// https://leetcode.com/submissions/detail/856310749/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountElements(int[] arr)
    {
        var set = arr.ToHashSet();
        return arr.Count(num => set.Contains(num + 1));
    }
}
