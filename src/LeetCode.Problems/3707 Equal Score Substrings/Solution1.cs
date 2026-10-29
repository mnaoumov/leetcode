namespace LeetCode.Problems._3707_Equal_Score_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-167/problems/equal-score-substrings/submissions/1798337602/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ScoreBalance(string s)
    {
        var sum = s.Select(Value).Sum();

        if (sum % 2 != 0)
        {
            return false;
        }

        var sumLeft = sum / 2;

        foreach (var letter in s)
        {
            sumLeft -= Value(letter);

            if (sumLeft <= 0)
            {
                break;
            }
        }

        return sumLeft == 0;
    }

    private static int Value(char letter) => letter - 'a' + 1;
}
