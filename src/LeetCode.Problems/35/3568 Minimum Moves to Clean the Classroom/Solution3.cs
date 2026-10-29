namespace LeetCode.Problems._3568_Minimum_Moves_to_Clean_the_Classroom;

/// <summary>
/// https://leetcode.com/problems/minimum-moves-to-clean-the-classroom/submissions/2127490933/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinMoves(string[] classroom, int energy)
    {
        var m = classroom.Length;
        var n = classroom[0].Length;

        const char startingPosition = 'S';
        const char litter = 'L';
        const char obstacle = 'X';
        const char reset = 'R';

        var queue = new Queue<(int row, int column, int energyLeft, int moves, int collectedLitterMask)>();

        var litterPositions = new List<(int row, int column)>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var cell = classroom[row][column];

                switch (cell)
                {
                    case startingPosition:
                        queue.Enqueue((row, column, energy, 0, 0));
                        break;
                    case litter:
                        litterPositions.Add((row, column));
                        break;
                }
            }
        }

        if (litterPositions.Count == 0)
        {
            return 0;
        }

        var fullMask = (1 << litterPositions.Count) - 1;

        var deltas = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        var visited = new HashSet<(int row, int column, int energy, int collectedLitterMask)>();

        while (queue.Count > 0)
        {
            var (row, column, energyLeft, moves, collectedLitterMask) = queue.Dequeue();

            if (!visited.Add((row, column, energyLeft, collectedLitterMask)))
            {
                continue;
            }

            var shouldStop = false;

            switch (classroom[row][column])
            {
                case litter:
                    var litterIndex = litterPositions.IndexOf((row, column));
                    collectedLitterMask |= (1 << litterIndex);

                    if (collectedLitterMask == fullMask)
                    {
                        return moves;
                    }
                    break;
                case obstacle:
                    shouldStop = true;
                    break;
                case reset:
                    energyLeft = energy;
                    break;
            }

            if (shouldStop || energyLeft == 0)
            {
                continue;
            }

            foreach (var (dRow, dColumn) in deltas)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                queue.Enqueue((nextRow, nextColumn, energyLeft - 1, moves + 1, collectedLitterMask));
            }
        }

        return -1;
    }
}
