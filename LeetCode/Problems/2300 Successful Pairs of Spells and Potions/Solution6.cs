using JetBrains.Annotations;

namespace LeetCode._2300_Successful_Pairs_of_Spells_and_Potions;

/// <summary>
/// https://leetcode.com/submissions/detail/914706781/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
    {
        Array.Sort(potions);
        var n = spells.Length;
        var m = potions.Length;
        var result = new int[n];

        const int maxStrength = 100_000;

        var minSpellStrength = success / maxStrength;

        for (var i = 0; i < n; i++)
        {
            var spellStrength = spells[i];

            if (spellStrength < minSpellStrength)
            {
                continue;
            }

            var minPotionStrength = (int) ((success + spellStrength - 1) / spellStrength);

            if (minPotionStrength > maxStrength)
            {
                continue;
            }

            var low = 0;
            var high = m - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (potions[mid] < minPotionStrength)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            result[i] = m - low;
        }

        return result;
    }
}
