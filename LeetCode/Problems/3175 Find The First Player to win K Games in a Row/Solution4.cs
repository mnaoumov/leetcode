using JetBrains.Annotations;

namespace LeetCode.Problems._3175_Find_The_First_Player_to_win_K_Games_in_a_Row;

/// <summary>
/// https://leetcode.com/submissions/detail/1281717865/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int FindWinningPlayer(int[] skills, int k)
    {
        var winningSkill = skills[0];
        var ans = 0;
        var winsCount = 0;
        var maxSkill = skills.Max();

        if (winningSkill == maxSkill)
        {
            return ans;
        }

        for (var i = 1; i < skills.Length; i++)
        {
            var skill = skills[i];

            if (skill < winningSkill)
            {
                winsCount++;

                if (winsCount == k)
                {
                    return ans;
                }
            }
            else
            {
                ans = i;
                winsCount = 1;
                winningSkill = skill;

                if (winningSkill == maxSkill)
                {
                    return ans;
                }
            }
        }

        throw new InvalidOperationException();
    }
}
