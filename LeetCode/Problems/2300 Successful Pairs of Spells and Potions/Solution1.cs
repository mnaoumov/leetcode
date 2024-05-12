using JetBrains.Annotations;

namespace LeetCode.Problems._2300_Successful_Pairs_of_Spells_and_Potions;

/// <summary>
/// https://leetcode.com/submissions/detail/914695537/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        var n = spells.Length;
        var m = potions.Length;
        var result = new int[n];

        for (var i = 0; i < n; i++)
        {
            var minPotionStrength = (success + spells[i] - 1) / spells[i];

            if (minPotionStrength > int.MaxValue)
            {
                continue;
            }

            var potionIndex = Array.BinarySearch(potions, (int) minPotionStrength);

            if (potionIndex < 0)
            {
                potionIndex = ~potionIndex;
            }

            result[i] = m - potionIndex;
        }

        return result;
    }
}
