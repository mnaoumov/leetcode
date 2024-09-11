namespace LeetCode.Problems._1539_Kth_Missing_Positive_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/909838379/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindKthPositive(int[] arr, int k)
    {
        var left = 0;
        var right = arr.Length;

        while (left < right)
        {
            var mid = left + (right - left >> 1);
            var expected = mid + 1;
            var diff = arr[mid] - expected;

            if (diff > k)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return (right < arr.Length ? 1 : 0) + right + k;
    }
}
