using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1438_Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit;

/// <summary>
/// https://leetcode.com/submissions/detail/899527324/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestSubarray(int[] nums, int limit)
    {
        var i = 0;
        var j = 0;
        var result = 0;
        var mins = new Stack<int>();
        var maxes = new Stack<int>();

        while (j < nums.Length)
        {
            var num = nums[j];

            if (mins.Count == 0 || num <= mins.Peek())
            {
                mins.Push(num);
            }

            if (maxes.Count == 0 || num >= maxes.Peek())
            {
                maxes.Push(num);
            }

            while (maxes.Peek() - mins.Peek() > limit)
            {
                var oldNum = nums[i];

                if (oldNum == mins.Peek())
                {
                    mins.Pop();

                    if (mins.Count == 0)
                    {
                        mins.Push(num);
                    }
                }

                if (oldNum == maxes.Peek())
                {
                    maxes.Pop();

                    if (maxes.Count == 0)
                    {
                        maxes.Push(num);
                    }
                }

                i++;
            }

            result = Math.Max(result, j - i + 1);
            j++;
        }

        return result;
    }
}
