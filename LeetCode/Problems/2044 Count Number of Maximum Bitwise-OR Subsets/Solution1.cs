namespace LeetCode.Problems._2044_Count_Number_of_Maximum_Bitwise_OR_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/1425941674/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountMaxOrSubsets(int[] nums)
    {
        var maxOr = Or(nums);
        return Subsets(nums).Count(subset => Or(subset) == maxOr);
    }

    private static IEnumerable<IEnumerable<int>> Subsets(int[] nums)
    {
        if (nums.Length == 0)
        {
            yield return Array.Empty<int>();
            yield break;
        }

        foreach (var subset in Subsets(nums.Skip(1).ToArray()))
        {
            var subsetArray = subset.ToArray();
            yield return subsetArray;
            yield return new[] { nums[0] }.Concat(subsetArray);
        }

    }

    private static int Or(IEnumerable<int> nums) => nums.Aggregate(0, (x, y) => x | y);
}
