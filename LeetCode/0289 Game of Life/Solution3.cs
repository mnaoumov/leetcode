using JetBrains.Annotations;

namespace LeetCode._0289_Game_of_Life;

/// <summary>
/// https://leetcode.com/submissions/detail/875896903/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public void GameOfLife(int[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var liveNeighborsCount = 0;

                for (var dRow = -1; dRow <= 1; dRow++)
                {
                    for (var dColumn = -1; dColumn <= 1; dColumn++)
                    {
                        var neighborRow = row + dRow;
                        var neighborColumn = column + dColumn;

                        if (neighborRow < 0 || neighborRow >= m || neighborColumn < 0 || neighborColumn >= n ||
                            dRow == 0 && dColumn == 0)
                        {
                            continue;
                        }

                        var neighborState = (State) board[neighborRow][neighborColumn];

                        if (neighborState is State.Live or State.FutureDead)
                        {
                            liveNeighborsCount++;
                        }
                    }
                }

                switch ((State) board[row][column])
                {
                    case State.Dead:
                        {
                            if (liveNeighborsCount == 3)
                            {
                                board[row][column] = (int) State.FutureLive;
                            }

                            break;
                        }
                    case State.Live:
                        {
                            if (liveNeighborsCount is < 2 or > 3)
                            {
                                board[row][column] = (int) State.FutureDead;
                            }

                            break;
                        }
                    case State.FutureDead:
                    case State.FutureLive:
                    default:
                        throw new ArgumentOutOfRangeException("", default(Exception));
                }
            }
        }

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                switch ((State) board[row][column])
                {
                    case State.FutureDead:
                        board[row][column] = (int) State.Dead;
                        break;
                    case State.FutureLive:
                        board[row][column] = (int) State.Live;
                        break;
                    case State.Dead:
                    case State.Live:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("", default(Exception));
                }
            }
        }
    }

    private enum State
    {
        Dead = 0,
        Live = 1,
        FutureDead = 2,
        FutureLive = 3
    }
}
