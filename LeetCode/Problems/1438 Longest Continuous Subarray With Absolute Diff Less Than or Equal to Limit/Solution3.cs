using JetBrains.Annotations;

namespace LeetCode.Problems._1438_Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit;

/// <summary>
/// https://leetcode.com/submissions/detail/899538584/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestSubarray(int[] nums, int limit)
    {
        var i = 0;
        var j = 0;
        var result = 0;
        var mins = new LinkedList<int>();
        var maxes = new LinkedList<int>();

        while (j < nums.Length)
        {
            var num = nums[j];

            while (mins.Count > 0 && mins.Last!.Value > num)
            {
                mins.RemoveLast();
            }

            while (maxes.Count > 0 && maxes.Last!.Value < num)
            {
                maxes.RemoveLast();
            }

            mins.AddLast(num);
            maxes.AddLast(num);

            while (maxes.First!.Value - mins.First!.Value > limit)
            {
                if (nums[i] == mins.First.Value)
                {
                    mins.RemoveFirst();
                }

                if (nums[i] == maxes.First.Value)
                {
                    maxes.RemoveFirst();
                }

                i++;
            }

            result = Math.Max(result, j - i + 1);
            j++;
        }

        return result;
    }
}
