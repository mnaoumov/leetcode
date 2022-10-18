using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0289_Game_of_Life;

/// <summary>
/// https://leetcode.com/submissions/detail/205278883/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public void GameOfLife(int[][] board)
    {
        int rowCount = board.Length;
        int columnCount = board[0].Length;

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                bool wasAlive = WasAlive(board, row, column);
                int aliveNeighborsCount = 0;

                for (int neighborRow = row - 1; neighborRow <= row + 1; neighborRow++)
                {
                    for (int neighborColumn = column - 1; neighborColumn <= column + 1; neighborColumn++)
                    {
                        if (neighborRow < 0 || neighborRow >= rowCount || neighborColumn < 0 ||
                            neighborColumn >= columnCount || (neighborRow == row && neighborColumn == column))
                        {
                            continue;
                        }

                        if (WasAlive(board, neighborRow, neighborColumn))
                        {
                            aliveNeighborsCount++;
                        }
                    }
                }

                board[row][column] = (int)GetNextAliveState(wasAlive, aliveNeighborsCount);
            }
        }
        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < columnCount; column++)
            {
                var state = (State)board[row][column];
                board[row][column] = state == State.WasAliveBecameAlive || state == State.WasDeadBecameAlive
                    ? (int)State.WasAliveBecameAlive
                    : (int)State.WasDeadBecameDead;
            }
        }
    }

    private static bool WasAlive(int[][] board, int row, int column)
    {
        State state = (State)board[row][column];
        return state == State.WasAliveBecameAlive || state == State.WasAliveBecameDead;
    }

    private static State GetNextAliveState(bool wasAlive, int aliveNeighborsCount)
    {
        if (wasAlive && aliveNeighborsCount < 2)
        {
            return State.WasAliveBecameDead;
        }

        if (wasAlive && (aliveNeighborsCount == 2 || aliveNeighborsCount == 3))
        {
            return State.WasAliveBecameAlive;
        }

        if (wasAlive && aliveNeighborsCount > 3)
        {
            return State.WasAliveBecameDead;
        }

        if (!wasAlive && aliveNeighborsCount == 3)
        {
            return State.WasDeadBecameAlive;
        }

        return State.WasDeadBecameDead;
    }

    private enum State
    {
        WasDeadBecameDead = 0,
        WasAliveBecameAlive = 1,
        WasDeadBecameAlive = 2,
        WasAliveBecameDead = 3
    }
}
