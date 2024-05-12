using JetBrains.Annotations;

namespace LeetCode.Problems._2971_Find_Polygon_With_the_Largest_Perimeter;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-120/submissions/detail/1126668342/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);

        var sum = 0L;
        var ans = -1L;

        for (var i = 0; i < nums.Length; i++)
        {
            var previousSum = sum;
            sum += nums[i];

            if (i >= 2 && previousSum > nums[i])
            {
                ans = sum;
            }
        }

        return ans;
    }
}
