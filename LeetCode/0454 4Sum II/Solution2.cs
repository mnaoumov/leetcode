using JetBrains.Annotations;

namespace LeetCode._0454_4Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/944084588/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
    {
        var n = nums1.Length;

        var counts12 = new Dictionary<int, int>();

        var ans = 0;

        for (var i1 = 0; i1 < n; i1++)
        {
            for (var i2 = 0; i2 < n; i2++)
            {
                var sum12 = nums1[i1] + nums2[i2];
                counts12[sum12] = counts12.GetValueOrDefault(sum12) + 1;
            }
        }

        for (var i3 = 0; i3 < n; i3++)
        {
            for (var i4 = 0; i4 < n; i4++)
            {
                var sum34 = nums3[i3] + nums4[i4];
                ans += counts12.GetValueOrDefault(-sum34);
            }
        }

        return ans;
    }
}
