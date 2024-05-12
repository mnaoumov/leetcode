using JetBrains.Annotations;

namespace LeetCode._2733_Neither_Minimum_nor_Maximum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-349/submissions/detail/968481725/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindNonMinOrMax(int[] nums)
    {
        if (nums.Length <= 2)
        {
            return -1;
        }

        var min = nums[0];
        var max = nums[0];


        for (var i = 1; i < nums.Length; i++)
        {
            var num = nums[i];

            if (num < min)
            {
                (min, num) = (num, min);
            }

            if (num > max)
            {
                (max, num) = (num, max);
            }

            if (min < num && num < max)
            {
                return num;
            }
        }

        throw new InvalidOperationException();
    }
}
