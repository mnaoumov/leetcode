namespace LeetCode.Problems._2248_Intersection_of_Multiple_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/856347954/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<int> Intersection(int[][] nums)
    {
        var set = nums[0].ToHashSet();

        foreach (var arr in nums.Skip(1))
        {
            set.IntersectWith(arr);
        }

        return set.ToArray();
    }
}
