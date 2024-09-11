using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1438_Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit;

/// <summary>
/// https://leetcode.com/submissions/detail/899531861/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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

            var temp = new Stack<int>();

            while (mins.TryPeek(out var min) && min < num)
            {
                temp.Push(mins.Pop());
            }

            mins.Push(num);

            while (temp.Count > 0)
            {
                mins.Push(temp.Pop());
            }

            while (maxes.TryPeek(out var max) && max > num)
            {
                temp.Push(maxes.Pop());
            }

            maxes.Push(num);

            while (temp.Count > 0)
            {
                maxes.Push(temp.Pop());
            }

            while (maxes.Peek() - mins.Peek() > limit)
            {
                var oldNum = nums[i];

                if (oldNum == mins.Peek())
                {
                    mins.Pop();
                }

                if (oldNum == maxes.Peek())
                {
                    maxes.Pop();
                }

                i++;
            }

            result = Math.Max(result, j - i + 1);
            j++;
        }

        return result;
    }
}
