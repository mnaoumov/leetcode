using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0289_Game_of_Life;

/// <summary>
/// https://leetcode.com/submissions/detail/205276260/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void GameOfLife(int[][] board)
    {
        const int aliveState = 1;
        const int deadState = 0;

        int rowCount = board.Length;
        int columnCount = board[0].Length;

        var aliveNeighborsCounts = new int[rowCount, columnCount];

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                if (board[row][column] != aliveState)
                {
                    continue;
                }

                for (int neighborRow = row - 1; neighborRow <= row + 1; neighborRow++)
                {
                    for (int neighborColumn = column - 1; neighborColumn <= column + 1; neighborColumn++)
                    {
                        if (neighborRow < 0 || neighborRow >= rowCount || neighborColumn < 0 ||
                            neighborColumn >= columnCount || (neighborRow == row && neighborColumn == column))
                        {
                            continue;
                        }

                        aliveNeighborsCounts[neighborRow, neighborColumn]++;
                    }
                }
            }
        }

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                var isAlive = board[row][column] == aliveState;

                board[row][column] = IsAliveNextStep(isAlive, aliveNeighborsCounts[row, column]) ? aliveState : deadState;
            }
        }
    }

    private static bool IsAliveNextStep(bool isAlive, int aliveNeighborsCount)
    {
        if (isAlive && aliveNeighborsCount < 2)
        {
            return false;
        }

        if (isAlive && (aliveNeighborsCount == 2 || aliveNeighborsCount == 3))
        {
            return true;
        }

        if (isAlive && aliveNeighborsCount > 3)
        {
            return false;
        }

        if (!isAlive && aliveNeighborsCount == 3)
        {
            return true;
        }

        return isAlive;
    }
}
