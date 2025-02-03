namespace LeetCode.Problems._1752_Check_if_Array_Is_Sorted_and_Rotated;

/// <summary>
/// https://leetcode.com/problems/check-if-array-is-sorted-and-rotated/submissions/1528251091/?envType=daily-question&envId=2025-02-02
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool Check(int[] nums)
    {
        var n = nums.Length;

        var rotationCheckStarted = false;

        for (var i = 0; i < n - 1; i++)
        {
            if (nums[i] <= nums[i + 1])
            {
                if (rotationCheckStarted)
                {
                    if (nums[i + 1] > nums[0])
                    {
                        return false;
                    }
                }
                continue;
            }

            if (rotationCheckStarted)
            {
                return false;
            }

            rotationCheckStarted = true;
        }

        return true;
    }
}
