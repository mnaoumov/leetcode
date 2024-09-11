using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0031_Next_Permutation;

/// <summary>
/// https://leetcode.com/submissions/detail/198321735/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public void NextPermutation(int[] nums)
    {
        if (nums.Length < 2)
        {
            return;
        }

        var lastLocalMaximum = nums.Length - 1;

        while (lastLocalMaximum > 0 && nums[lastLocalMaximum] < nums[lastLocalMaximum - 1])
        {
            lastLocalMaximum--;
        }

        if (lastLocalMaximum > 0)
        {
            int i = lastLocalMaximum;
            while (i < nums.Length - 1 && nums[i + 1] > nums[lastLocalMaximum - 1])
            {
                i++;
            }

            Swap(nums, lastLocalMaximum - 1, i);
        }

        for (int i = lastLocalMaximum; i < (nums.Length + lastLocalMaximum) / 2; i++)
        {
            Swap(nums, i, nums.Length - 1 - i + lastLocalMaximum);
        }
    }

    private static void Swap(int[] nums, int i, int j)
    {
        (nums[i], nums[j]) = (nums[j], nums[i]);
    }
}
