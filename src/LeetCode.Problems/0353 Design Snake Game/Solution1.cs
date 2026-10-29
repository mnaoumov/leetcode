namespace LeetCode.Problems._0353_Design_Snake_Game;

/// <summary>
/// https://leetcode.com/problems/design-snake-game/submissions/1623113315/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISnakeGame Create(int width, int height, int[][] food) => new SnakeGame(width, height, food);

    private class SnakeGame : ISnakeGame
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Queue<Cell> _foodCellsQueue = new();
        private int _score;
        private readonly LinkedList<Cell> _snakeCellsList = new();
        private readonly HashSet<Cell> _snakeCells = new();

        public SnakeGame(int width, int height, int[][] food)
        {
            _width = width;
            _height = height;

            foreach (var entry in food)
            {
                var r = entry[0];
                var c = entry[1];
                _foodCellsQueue.Enqueue(new Cell(r, c));
            }

            var startCell = new Cell(0, 0);
            _snakeCellsList.AddFirst(startCell);
            _snakeCells.Add(startCell);
        }
    
        public int Move(string direction)
        {
            const int gameOverScore = -1;

            if (_score == gameOverScore)
            {
                return gameOverScore;
            }

            var snakeHead = _snakeCellsList.First!;

            var newSnakeHead = direction switch
            {
                "U" => snakeHead.Value with { Row = snakeHead.Value.Row - 1 },
                "D" => snakeHead.Value with { Row = snakeHead.Value.Row + 1 },
                "L" => snakeHead.Value with { Column = snakeHead.Value.Column - 1 },
                "R" => snakeHead.Value with { Column = snakeHead.Value.Column + 1 },
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

            var snakeTail = _snakeCellsList.Last!;
            _snakeCells.Remove(snakeTail.Value);
            _snakeCellsList.RemoveLast();

            if (newSnakeHead.Row < 0 || newSnakeHead.Row >= _height ||
                newSnakeHead.Column < 0 || newSnakeHead.Column >= _width ||
                _snakeCells.Contains(newSnakeHead))
            {
                _score = gameOverScore;
                return gameOverScore;
            }

            if (_foodCellsQueue.TryPeek(out var foodCell) && newSnakeHead == foodCell)
            {
                _foodCellsQueue.Dequeue();
                _score++;
                _snakeCellsList.AddLast(snakeTail.Value);
                _snakeCells.Add(snakeTail.Value);
            }

            _snakeCellsList.AddFirst(newSnakeHead);
            _snakeCells.Add(newSnakeHead);
            return _score;
        }

        private record Cell(int Row, int Column);
    }
}
