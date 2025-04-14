namespace LeetCode.Problems._3494_Find_the_Minimum_Amount_of_Time_to_Brew_Potions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-442/problems/find-the-minimum-amount-of-time-to-brew-potions/submissions/1582859348/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinTime(int[] skill, int[] mana)
    {
        var time = 0L;
        var n = skill.Length;
        var totalSkills = new int[n + 1];
        for (var i = 0; i < n; i++)
        {
            totalSkills[i + 1] = totalSkills[i] + skill[i];
        }

        for (var j = 0; j < mana.Length; j++)
        {
            var currentPotionMana = mana[j];
            var previousPotionMana = j == 0 ? 0 : mana[j - 1];

            var nextTime = time;

            for (var i = 0; i < n; i++)
            {
                nextTime = Math.Max(nextTime,
                    time + 1L * totalSkills[i + 1] * (previousPotionMana - currentPotionMana) +
                    skill[i] * currentPotionMana);
            }

            time = nextTime;
        }

        return time + 1L * totalSkills[n] * mana[^1];
    }
}
