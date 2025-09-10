namespace LeetCode.Problems._3664_Two_Letter_Card_Game;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-164/problems/two-letter-card-game/submissions/1753634795/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int Score(string[] cards, char x)
    {
        var firstXCount = 0;
        var secondXCount = 0;
        var doubleXCount = 0;

        foreach (var card in cards)
        {
            if (card[0] == x && card[1] == x)
            {
                doubleXCount++;
            }
            else if (card[0] == x)
            {
                firstXCount++;
            }
            else if (card[1] == x)
            {
                secondXCount++;
            }
        }

        var ans = firstXCount / 2 + secondXCount / 2;

        if (firstXCount % 2 == 1 && doubleXCount > 0)
        {
            ans++;
            doubleXCount--;
        }

        if (secondXCount % 2 == 1 && doubleXCount > 0)
        {
            ans++;
            doubleXCount--;
        }

        ans += doubleXCount / 2;

        return ans;
    }
}
