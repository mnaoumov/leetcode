namespace LeetCode.Problems._2248_Intersection_of_Multiple_Arrays;

/// <seealso href="https://leetcode.com/submissions/detail/856348495/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> Intersection(int[][] nums)
    {
        var set = nums[0].ToHashSet();

        foreach (var arr in nums.Skip(1))
        {
            set.IntersectWith(arr);
        }

        return set.OrderBy(x => x).ToArray();
    }
}
