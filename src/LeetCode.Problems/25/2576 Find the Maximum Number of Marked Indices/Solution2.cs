namespace LeetCode.Problems._2576_Find_the_Maximum_Number_of_Marked_Indices;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-334/submissions/detail/905051011/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxNumOfMarkedIndices(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;

        var i = 0;
        var j = n / 2;
        var result = 0;

        while (i < n / 2)
        {
            while (j < n && nums[i] * 2 > nums[j])
            {
                j++;
            }

            if (j == n)
            {
                break;
            }

            i++;
            j++;
            result += 2;
        }

        return result;
    }
}
