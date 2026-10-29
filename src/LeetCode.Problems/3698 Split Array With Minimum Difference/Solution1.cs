namespace LeetCode.Problems._3698_Split_Array_With_Minimum_Difference;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-469/problems/split-array-with-minimum-difference/submissions/1784794751/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long SplitArray(int[] nums)
    {
        var n = nums.Length;
        const long impossible = long.MinValue;
        var leftSums = new long[n];
        var rightSums = new long[n];
        Array.Fill(leftSums, impossible);
        Array.Fill(rightSums, impossible);

        leftSums[0] = nums[0];
        rightSums[^1] = nums[^1];
        var maxLeftIndex = 0;
        var minRightIndex = n - 1;

        for (var i = 1; i < n; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                break;
            }

            leftSums[i] = leftSums[i - 1] + nums[i];
            maxLeftIndex = i;
        }

        for (var i = n - 2; i >= 0; i--)
        {
            if (nums[i] <= nums[i + 1])
            {
                break;
            }

            rightSums[i] = rightSums[i + 1] + nums[i];
            minRightIndex = i;
        }

        if (maxLeftIndex + 1 < minRightIndex)
        {
            return -1;
        }

        var ans = long.MaxValue;

        for (var leftIndex = minRightIndex - 1; leftIndex <= maxLeftIndex; leftIndex++)
        {
            ans = Math.Min(ans, Math.Abs(leftSums[leftIndex] - rightSums[leftIndex + 1]));
        }

        return ans;
    }
}
