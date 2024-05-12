using JetBrains.Annotations;

namespace LeetCode.Problems._2784_Check_if_Array_is_Good;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-109/submissions/detail/1000975196/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsGood(int[] nums)
    {
        var n = nums.Length - 1;
        var counts = new int[n + 1];

        foreach (var num in nums)
        {
            if (num < 1 || num > n)
            {
                return false;
            }

            counts[num]++;

            if (num < n)
            {
                if (counts[num] > 1)
                {
                    return false;
                }
            }
            else if (counts[num] > 2)
            {
                return false;
            }
        }

        return true;
    }
}
