using JetBrains.Annotations;

namespace LeetCode._3041_Maximize_Consecutive_Elements_in_an_Array_After_Modification;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution4 : ISolution
{
    public int MaxSelectedElements(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;

        var sequenceLengthsIfKeep = new int[n];
        var sequenceLengthsIfIncrease = new int[n];

        sequenceLengthsIfKeep[^1] = 1;
        sequenceLengthsIfIncrease[^1] = 1;

        var ans = 1;

        for (var i = n - 2; i >= 0; i--)
        {
            if (nums[i] == nums[i + 1] - 1)
            {
                sequenceLengthsIfKeep[i] = sequenceLengthsIfKeep[i + 1] + 1;
                sequenceLengthsIfIncrease[i] = sequenceLengthsIfIncrease[i + 1] + 1;
            }
            else if (nums[i] == nums[i + 1])
            {
                sequenceLengthsIfKeep[i] = sequenceLengthsIfIncrease[i + 1] + 1;


                sequenceLengthsIfIncrease[i] = 1;
            }
            else if (nums[i] == nums[i + 1] - 2)
            {
                sequenceLengthsIfIncrease[i] = sequenceLengthsIfKeep[i + 1] + 1;
                sequenceLengthsIfKeep[i] = 1;
            }
            else
            {
                sequenceLengthsIfKeep[i] = 1;
                sequenceLengthsIfIncrease[i] = 1;
            }

            ans = Math.Max(ans, sequenceLengthsIfKeep[i]);
            ans = Math.Max(ans, sequenceLengthsIfIncrease[i]);
        }

        return ans;
    }
}
