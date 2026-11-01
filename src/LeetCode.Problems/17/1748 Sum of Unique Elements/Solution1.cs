namespace LeetCode.Problems._1748_Sum_of_Unique_Elements;

/// <seealso href="https://leetcode.com/submissions/detail/898949507/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfUnique(int[] nums)
    {
        var set = new HashSet<int>();
        var unique = nums.ToHashSet();

        foreach (var num in nums)
        {
            if (!set.Add(num))
            {
                unique.Remove(num);
            }
        }

        return unique.Sum();
    }
}
