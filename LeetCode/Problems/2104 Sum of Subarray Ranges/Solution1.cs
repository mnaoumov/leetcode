using JetBrains.Annotations;

namespace LeetCode._2104_Sum_of_Subarray_Ranges;

/// <summary>
/// https://leetcode.com/submissions/detail/903878524/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long SubArrayRanges(int[] nums)
    {
        var result = 0L;

        var mins = new Stack<(int num, int count)>();
        var maxes = new Stack<(int num, int count)>();
        var minsSum = 0L;
        var maxesSum = 0L;

        foreach (var num in nums)
        {
            var count = 1;
            while (mins.TryPeek(out var x) && x.num > num)
            {
                minsSum -= x.num * x.count;
                count += x.count;
                mins.Pop();
            }

            minsSum += count * num;
            mins.Push((num, count));

            count = 1;
            while (maxes.TryPeek(out var x) && x.num < num)
            {
                maxesSum -= x.num * x.count;
                count += x.count;
                maxes.Pop();
            }

            maxesSum += count * num;
            maxes.Push((num, count));

            result += maxesSum - minsSum;
        }

        return result;
    }
}
