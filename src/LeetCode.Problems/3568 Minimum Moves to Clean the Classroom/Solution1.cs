using System.Collections.Immutable;

namespace LeetCode.Problems._3568_Minimum_Moves_to_Clean_the_Classroom;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-452/problems/minimum-moves-to-clean-the-classroom/submissions/1650324953/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinMoves(string[] classroom, int energy)
    {
        var m = classroom.Length;
        var n = classroom[0].Length;

        const char startingPosition = 'S';
        const char litter = 'L';
        const char obstacle = 'X';
        const char reset = 'R';

        var queue = new Queue<(int row, int column, int energyLeft, int moves, ImmutableHashSet<(int row, int column)> collectedLitterPositions, ImmutableDictionary<(int row, int column), int> maxEnergyMap)>();

        var totalLitterCount = 0;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var cell = classroom[row][column];

                switch (cell)
                {
                    case startingPosition:
                        queue.Enqueue((row, column, energy, 0, ImmutableHashSet<(int row, int column)>.Empty, ImmutableDictionary<(int row, int column), int>.Empty));
                        break;
                    case litter:
                        totalLitterCount++;
                        break;
                }
            }
        }

        if (totalLitterCount == 0)
        {
            return 0;
        }

        var deltas = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        while (queue.Count > 0)
        {
            var (row, column, energyLeft, moves, collectedLitterPositions, maxEnergyMap) = queue.Dequeue();

            var shouldStop = false;

            switch (classroom[row][column])
            {
                case litter:
                    collectedLitterPositions = collectedLitterPositions.Add((row, column));

                    if (collectedLitterPositions.Count == totalLitterCount)
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

            if (shouldStop || energyLeft == 0 || maxEnergyMap.GetValueOrDefault((row, column), 0) >= energyLeft)
            {
                continue;
            }

            maxEnergyMap = maxEnergyMap.SetItem((row, column), energyLeft);

            foreach (var (dRow, dColumn) in deltas)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                queue.Enqueue((nextRow, nextColumn, energyLeft - 1, moves + 1, collectedLitterPositions, maxEnergyMap));
            }
        }

        return -1;
    }
}
