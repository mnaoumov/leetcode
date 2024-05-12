using JetBrains.Annotations;

namespace LeetCode.Problems._1539_Kth_Missing_Positive_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/909840249/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int FindKthPositive(int[] arr, int k)
    {
        var left = 0;
        var right = arr.Length - 1;

        while (left <= right)
        {
            var mid = left + (right - left >> 1);
            var expected = mid + 1;
            var diff = arr[mid] - expected;

            if (diff <= k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return right == 0 ? k : right + 1 + k;
    }
}
