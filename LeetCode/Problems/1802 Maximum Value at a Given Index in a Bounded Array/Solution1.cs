using JetBrains.Annotations;

namespace LeetCode.Problems._1802_Maximum_Value_at_a_Given_Index_in_a_Bounded_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/953605648/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxValue(int n, int index, int maxSum)
    {
        var low = 0;
        var high = n - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var amountLeft = Math.Min(mid - 1, index);
            var amountRight = Math.Min(mid - 1, n - 1 - index);
            var sum = 1L * mid * (amountLeft + amountRight + 1) - 1L * amountLeft * (amountLeft + 1) / 2 -
                      1L * amountRight * (amountRight + 1) / 2;

            if (sum <= maxSum)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;
    }
}
