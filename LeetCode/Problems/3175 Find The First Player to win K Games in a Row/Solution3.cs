namespace LeetCode.Problems._3175_Find_The_First_Player_to_win_K_Games_in_a_Row;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-132/submissions/detail/1281707694/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public int FindWinningPlayer(int[] skills, int k)
    {
        var winningSkill = int.MinValue;
        var ans = -1;
        var winsCount = 0;
        var maxSkill = skills.Max();

        for (var i = 0; i < skills.Length; i++)
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

                if (skill == maxSkill)
                {
                    return ans;
                }
            }
        }

        throw new InvalidOperationException();
    }
}
