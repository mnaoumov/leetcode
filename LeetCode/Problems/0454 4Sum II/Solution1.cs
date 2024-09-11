namespace LeetCode.Problems._0454_4Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/944082440/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var n = nums1.Length;

        var counts4 = nums4.GroupBy(num4 => num4).ToDictionary(g => (long) g.Key, g => g.Count());

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                for (var k = 0; k < n; k++)
                {
                    var sum3 = 0L + nums1[i] + nums2[j] + nums3[k];
                    ans += counts4.GetValueOrDefault(-sum3);
                }
            }
        }

        return ans;
    }
}
