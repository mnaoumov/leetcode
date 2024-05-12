using JetBrains.Annotations;

namespace LeetCode._2873_Maximum_Value_of_an_Ordered_Triplet_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-365/submissions/detail/1063583358/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumTripletValue(int[] nums)
    {
        var n = nums.Length;
        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                for (var k = j + 1; k < n; k++)
                {
                    var value = 1L * (nums[i] - nums[j]) * nums[k];
                    ans = Math.Max(ans, value);
                }
            }
        }

        return ans;
    }
}
