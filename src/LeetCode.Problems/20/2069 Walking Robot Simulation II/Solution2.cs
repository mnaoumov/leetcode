namespace LeetCode.Problems._2069_Walking_Robot_Simulation_II;

/// <summary>
/// https://leetcode.com/problems/walking-robot-simulation-ii/submissions/1971142738/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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
            num %= 2 * (_width + _height - 2);
            while (true)
            {
                var maxMovesAllowed = num;

                if (_dx == 1)
                {
                    maxMovesAllowed = Math.Min(maxMovesAllowed, _width - 1 - _x);
                }

                if (_dx == -1)
                {
                    maxMovesAllowed = Math.Min(maxMovesAllowed, _x);
                }

                if (_dy == 1)
                {
                    maxMovesAllowed = Math.Min(maxMovesAllowed, _height - 1 - _y);
                }

                if (_dy == -1)
                {
                    maxMovesAllowed = Math.Min(maxMovesAllowed, _y);
                }

                _x += maxMovesAllowed * _dx;
                _y += maxMovesAllowed * _dy;

                num -= maxMovesAllowed;

                if (num == 0)
                {
                    break;
                }

                (_dx, _dy) = (-_dy, _dx);
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
