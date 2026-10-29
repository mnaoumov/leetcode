namespace LeetCode.Problems._0657_Robot_Return_to_Origin;

/// <summary>
/// https://leetcode.com/problems/robot-return-to-origin/submissions/1970070400/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool JudgeCircle(string moves)
    {
        const char up = 'U';
        const char down = 'D';
        const char left = 'L';
        const char right = 'R';

        var x = 0;
        var y = 0;

        foreach (var move in moves)
        {
            switch (move)
            {
                case up:
                    y--;
                    break;
                case down:
                    y++;
                    break;
                case left:
                    x--;
                    break;
                case right:
                    x++;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        return x == 0 && y == 0;
    }
}
