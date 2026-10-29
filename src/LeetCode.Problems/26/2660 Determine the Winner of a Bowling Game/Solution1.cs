namespace LeetCode.Problems._2660_Determine_the_Winner_of_a_Bowling_Game;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941848496/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IsWinner(int[] player1, int[] player2)
    {
        var score1 = Score(player1);
        var score2 = Score(player2);

        return score1 > score2 ? 1 : score2 > score1 ? 2 : 0;
    }

    private static int Score(IReadOnlyList<int> hits)
    {
        var ans = 0;

        var lastTenIndex = int.MinValue;

        for (var i = 0; i < hits.Count; i++)
        {
            var hit = hits[i];

            if (i <= lastTenIndex + 2)
            {
                ans += 2 * hit;
            }
            else
            {
                ans += hit;
            }

            if (hit == 10)
            {
                lastTenIndex = i;
            }
        }

        return ans;
    }
}
