using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3077_Maximum_Strength_of_K_Disjoint_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1199969803/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution6 : ISolution
{
    public long MaximumStrength(int[] nums, int k)
    {
        var dp = new Dictionary<(int startingIndex, int arraysCount, bool isMandatoryToTakeAtStartingIndex), long>();
        var n = nums.Length;
        const long impossible = long.MinValue;

        for (var i = n; i >= 0; i--)
        {
            for (var j = 0; j <= k ; j++)
            {
                if (n - i < j)
                {
                    dp[(i, j, true)] = impossible;
                    dp[(i, j, false)] = impossible;
                }
                else if (j == 0)
                {
                    dp[(i, 0, true)] = impossible;
                    dp[(i, 0, false)] = 0;
                }
                else
                {
                    var sum = 1L * nums[i] * j * (j % 2 == 1 ? 1 : -1);

                    var next = Math.Max(
                        dp[(i + 1, j - 1, false)],
                        dp[(i + 1, j, true)]
                    );

                    dp[(i, j, true)] = next == impossible ? impossible : sum + next;

                    dp[(i, j, false)] =
                        Math.Max(
                            dp[(i + 1, j, false)],
                            dp[(i, j, true)]
                        );
                }
            }
        }

        return dp[(0, k, false)];
    }
}
