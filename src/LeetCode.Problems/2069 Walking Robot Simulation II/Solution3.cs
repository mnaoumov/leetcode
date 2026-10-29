namespace LeetCode.Problems._2069_Walking_Robot_Simulation_II;

/// <summary>
/// https://leetcode.com/problems/walking-robot-simulation-ii/submissions/1971170069/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IRobot Create(int width, int height) => new Robot(width, height);

    private sealed class Robot : IRobot
    {
        private readonly int _width;
        private readonly int _height;
        private int _cellIndex;
        private readonly int _bottomRightCellIndex;
        private readonly int _topRightCellIndex;
        private readonly int _topLeftCellIndex;
        private readonly int _bottomLeftCellIndex;

        public Robot(int width, int height)
        {
            _width = width;
            _height = height;
            _bottomRightCellIndex = _width - 1;
            _topRightCellIndex = _bottomRightCellIndex + _height - 1;
            _topLeftCellIndex = _topRightCellIndex + _width - 1;
            _bottomLeftCellIndex = _topLeftCellIndex + _height - 1;
        }

        public void Step(int num)
        {
            _cellIndex = 1 + (_cellIndex + num - 1) % _bottomLeftCellIndex;
        }

        public int[] GetPos()
        {
            if (_cellIndex == 0)
            {
                return new[] { 0, 0 };
            }

            if (0 < _cellIndex && _cellIndex <= _bottomRightCellIndex)
            {
                return new[] { _cellIndex, 0 };
            }

            if (_bottomRightCellIndex < _cellIndex && _cellIndex <= _topRightCellIndex)
            {
                return new[] { _width - 1, _cellIndex - _bottomRightCellIndex };
            }

            if (_topRightCellIndex < _cellIndex && _cellIndex <= _topLeftCellIndex)
            {
                return new[] { _width - 1 - (_cellIndex - _topRightCellIndex), _height - 1 };
            }

            if (_topLeftCellIndex < _cellIndex && _cellIndex <= _bottomLeftCellIndex)
            {
                return new[] { 0, _height - 1 - (_cellIndex - _topLeftCellIndex) };
            }

            throw new InvalidOperationException();
        }

        public string GetDir()
        {
            if (_cellIndex == 0)
            {
                return "East";
            }

            if (0 < _cellIndex && _cellIndex <= _bottomRightCellIndex)
            {
                return "East";
            }

            if (_bottomRightCellIndex < _cellIndex && _cellIndex <= _topRightCellIndex)
            {
                return "North";
            }

            if (_topRightCellIndex < _cellIndex && _cellIndex <= _topLeftCellIndex)
            {
                return "West";
            }

            if (_topLeftCellIndex < _cellIndex && _cellIndex <= _bottomLeftCellIndex)
            {
                return "South";
            }

            throw new InvalidOperationException();
        }
    }
}
