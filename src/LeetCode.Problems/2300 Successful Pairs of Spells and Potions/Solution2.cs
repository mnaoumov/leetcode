namespace LeetCode.Problems._2300_Successful_Pairs_of_Spells_and_Potions;

/// <summary>
/// https://leetcode.com/submissions/detail/914697618/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

            var low = 0;
            var high = m - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (potions[mid] < minPotionStrength)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }

            result[i] = m - low;
        }

        return result;
    }
}
