using JetBrains.Annotations;

namespace LeetCode._2956_Find_Common_Elements_Between_Two_Arrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-119/submissions/detail/1115746004/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindIntersectionValues(int[] nums1, int[] nums2)
    {
        var set1 = nums1.ToHashSet();
        var set2 = nums2.ToHashSet();

        var n = nums1.Length;
        var m = nums2.Length;

        var answer = new int[2];

        for (var i = 0; i < n; i++)
        {
            if (set2.Contains(nums1[i]))
            {
                answer[0]++;
            }
        }

        for (var j = 0; j < m; j++)
        {
            if (set1.Contains(nums2[j]))
            {
                answer[1]++;
            }
        }

        return answer;
    }
}
