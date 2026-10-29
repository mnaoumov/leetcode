namespace LeetCode.Problems._3248_Snake_in_Matrix;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-410/submissions/detail/1351511842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FinalPositionOfSnake(int n, IList<string> commands)
    {
        var position = 0;

        foreach (var command in commands)
        {
            switch (command)
            {
                case "UP":
                    position -= n;
                    break;
                case "DOWN":
                    position += n;
                    break;
                case "LEFT":
                    position--;
                    break;
                case "RIGHT":
                    position++;
                    break;
            }
        }

        return position;
    }
}
