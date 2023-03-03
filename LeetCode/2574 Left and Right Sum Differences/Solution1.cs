using JetBrains.Annotations;

namespace LeetCode._2574_Left_and_Right_Sum_Differences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-334/submissions/detail/904999709/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable once IdentifierTypo
    public int[] LeftRigthDifference(int[] nums)
    {
        var n = nums.Length;
        var leftSum = new int[n];
        var rightSum = new int[n];

        for (var i = 1; i < n; i++)
        {
            leftSum[i] = leftSum[i - 1] + nums[i - 1];
        }

        for (var i = n - 2; i >= 0; i--)
        {
            rightSum[i] = rightSum[i + 1] + nums[i + 1];
        }

        return leftSum.Zip(rightSum, (x, y) => Math.Abs(x - y)).ToArray();
    }
}
