namespace LeetCode.Problems._1760_Minimum_Limit_of_Balls_in_a_Bag;

/// <summary>
/// https://leetcode.com/submissions/detail/930988558/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        var low = 1;
        var high = nums.Max();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanHavePenalty(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanHavePenalty(int penalty)
        {
            var operationsLeft = maxOperations;

            foreach (var num in nums)
            {
                if (num <= penalty)
                {
                    continue;
                }

                operationsLeft -= (num - 1) / penalty;

                if (operationsLeft < 0)
                {
                    break;
                }
            }

            return operationsLeft >= 0;
        }
    }
}
