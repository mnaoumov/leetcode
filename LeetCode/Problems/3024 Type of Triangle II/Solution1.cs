using JetBrains.Annotations;

namespace LeetCode.Problems._3024_Type_of_Triangle_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-123/submissions/detail/1164825995/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string TriangleType(int[] nums)
    {
        Array.Sort(nums);
        var a = nums[0];
        var b = nums[1];
        var c = nums[2];

        if (c >= a + b)
        {
            return "none";
        }

        if (c == a)
        {
            return "equilateral";
        }

        if (c == b || b == a)
        {
            return "isosceles";
        }

        return "scalene";
    }
}
