namespace LeetCode.Problems._1018201_Score_Validator;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-182/problems/score-validator/submissions/1998914566/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ScoreValidator(string[] events)
    {
        var counter = 0;
        var score = 0;

        foreach (var @event in events)
        {
            switch (@event)
            {
                case "0":
                    break;
                case "1":
                case "WD":
                case "NB":
                    score++;
                    break;
                case "2":
                    score += 2;
                    break;
                case "3":
                    score += 3;
                    break;
                case "4":
                    score += 4;
                    break;
                case "6":
                    score += 6;
                    break;
                case "W":
                    counter++;
                    break;
            }

            if (counter == 10)
            {
                break;
            }
        }

        return new[] { score, counter };
    }
}
