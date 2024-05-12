using JetBrains.Annotations;

namespace LeetCode.Problems._3147_Taking_Maximum_Energy_From_the_Mystic_Dungeon;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-397/submissions/detail/1255684235/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        var n = energy.Length;

        var ans = int.MinValue;

        for (var i = 0; i < n; i++)
        {
            var currentEnergy = 0;

            for (var j = i; j < n; j += k)
            {
                currentEnergy += energy[j];
            }

            ans = Math.Max(ans, currentEnergy);
        }

        return ans;
    }
}
