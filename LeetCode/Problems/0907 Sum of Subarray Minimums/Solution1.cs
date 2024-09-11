using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0907_Sum_of_Subarray_Minimums;

/// <summary>
/// https://leetcode.com/submissions/detail/849712564/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int SumSubarrayMins(int[] arr)
    {
        var mins = Enumerable.Repeat(int.MaxValue, arr.Length).ToArray();
        var result = 0;
        const int modulo = 1000000007;

        for (var numIndex = 0; numIndex < arr.Length; numIndex++)
        {
            var num = arr[numIndex];

            for (var minIndex = 0; minIndex <= numIndex; minIndex++)
            {
                mins[minIndex] = Math.Min(mins[minIndex], num);
                result = (result + mins[minIndex]) % modulo;
            }
        }

        return result;
    }
}
