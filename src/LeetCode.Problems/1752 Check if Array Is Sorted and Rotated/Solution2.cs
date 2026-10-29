namespace LeetCode.Problems._1752_Check_if_Array_Is_Sorted_and_Rotated;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool Check(int[] nums)
    {
        var n = nums.Length;

        var rotationCheckStarted = false;

        for (var i = 0; i < n; i++)
        {
            if (i == n - 1 || nums[i] <= nums[i + 1])
            {
                if (rotationCheckStarted)
                {
                    if (nums[i] > nums[0])
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
