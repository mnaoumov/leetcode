namespace LeetCode.Problems._1426_Counting_Elements;

/// <seealso href="https://leetcode.com/submissions/detail/856310749/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountElements(int[] arr)
    {
        var set = arr.ToHashSet();
        return arr.Count(num => set.Contains(num + 1));
    }
}
