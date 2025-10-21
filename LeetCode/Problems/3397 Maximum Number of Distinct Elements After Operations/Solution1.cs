namespace LeetCode.Problems._3397_Maximum_Number_of_Distinct_Elements_After_Operations;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-distinct-elements-after-operations/submissions/1804644451/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDistinctElements(int[] nums, int k)
    {
        var ans = 0;

        var previous = -k;

        foreach (var num in nums.OrderBy(x => x))
        {
            if (previous < num - k)
            {
                ans++;
                previous = num - k;
            }
            else if (previous < num + k)
            {
                ans++;
                previous++;
            }
        }

        return ans;
    }
}
