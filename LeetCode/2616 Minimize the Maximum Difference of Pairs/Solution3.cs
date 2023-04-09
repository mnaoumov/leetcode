using JetBrains.Annotations;

namespace LeetCode._2616_Minimize_the_Maximum_Difference_of_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/930540656/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);

        var low = 0;
        var high = nums[^1] - nums[0];

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanChoose(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanChoose(int maxDiff)
        {
            var pairsLeft = p;

            for (var i = 0; i < nums.Length - 1; i++)
            {
                var diff = nums[i + 1] - nums[i];

                if (diff > maxDiff)
                {
                    continue;
                }

                pairsLeft--;

                if (pairsLeft == 0)
                {
                    return true;
                }

                i++;
            }

            return false;
        }
    }
}