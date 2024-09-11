namespace LeetCode.Problems._0489_Robot_Room_Cleaner;

/// <summary>
/// https://leetcode.com/submissions/detail/950514652/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void CleanRoom(Robot robot)
    {
        var directions = new (int dRow, int dColumn)[] { (-1, 0), (0, 1), (1, 0), (0, -1) };

        var seen = new HashSet<(int row, int column)>();

        Process(0, 0);
        return;

        void Process(int row, int column)
        {
            if (!seen.Add((row, column)))
            {
                return;
            }

            robot.Clean();

            for (var i = 0; i < 4; i++)
            {
                TurnRight(i);

                if (robot.Move())
                {
                    TurnRight(-i);

                    Process(row + directions[i].dRow, column + directions[i].dColumn);

                    TurnRight(i + 2);

                    robot.Move();

                    TurnRight(-i - 2);
                }
                else
                {
                    TurnRight(-i);
                }
            }
        }

        void TurnRight(int i)
        {
            switch ((4 + i % 4) % 4)
            {
                case 0:
                    return;
                case 1:
                    robot.TurnRight();
                    break;
                case 2:
                    robot.TurnRight();
                    robot.TurnRight();
                    break;
                case 3:
                    robot.TurnLeft();
                    break;
            }
        }
    }
}
