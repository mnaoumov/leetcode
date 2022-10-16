namespace LeetCode._2441_Largest_Positive_Integer_That_Exists_With_Its_Negative;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-315/submissions/detail/823374701/
/// </summary>
public class Solution1 : ISolution
{
    public int FindMaxK(int[] nums)
    {
        var set = new HashSet<int>(nums);

        var max = -1;

        foreach (var num in nums)
        {
            if (num > max && set.Contains(-num))
            {
                max = num;
            }
        }

        return max;
    }
}