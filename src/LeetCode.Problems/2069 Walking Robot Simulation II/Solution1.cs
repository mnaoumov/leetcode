namespace LeetCode.Problems._2069_Walking_Robot_Simulation_II;

/// <summary>
/// https://leetcode.com/problems/walking-robot-simulation-ii/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IRobot Create(int width, int height) => new Robot(width, height);

    private sealed class Robot : IRobot
    {
        private readonly int _width;
        private readonly int _height;
        private int _x;
        private int _y;
        private int _dx;
        private int _dy;

        public Robot(int width, int height)
        {
            _width = width;
            _height = height;
            _x = 0;
            _y = 0;
            _dx = 1;
            _dy = 0;
        }

        public void Step(int num)
        {
            for (var i = 0; i < num; i++)
            {
                while (true)
                {
                    var newX = _x + _dx;
                    var newY = _y + _dy;

                    if (0 <= newX && newX < _width && 0 <= newY && newY < _height)
                    {
                        _x = newX;
                        _y = newY;
                        break;
                    }

                    (_dx, _dy) = (-_dy, _dx);
                }
            }
        }

        public int[] GetPos() => new[] { _x, _y };

        public string GetDir()
        {
            if (_dx == 1 && _dy == 0)
            {
                return "East";
            }

            if (_dx == -1 && _dy == 0)
            {
                return "West";
            }

            if (_dx == 0 && _dy == 1)
            {
                return "North";
            }

            if (_dx == 0 && _dy == -1)
            {
                return "South";
            }

            throw new InvalidOperationException();
        }
    }
}
