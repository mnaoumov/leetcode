using JetBrains.Annotations;

namespace LeetCode.Problems._0305_Number_of_Islands_II;

/// <summary>
/// https://leetcode.com/submissions/detail/898645350/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        var result = 0;
        var parents = new Dictionary<(int row, int column), (int row, int column)>();
        var deltas = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        return positions.Select(GetResult).ToArray();

        int GetResult(int[] position)
        {
            var cell = (row: position[0], column: position[1]);

            if (parents.ContainsKey(cell))
            {
                return result;
            }

            result++;
            parents[cell] = cell;

            foreach (var (dRow, dColumn) in deltas)
            {
                var neighborCell = (row: cell.row + dRow, column: cell.column + dColumn);

                if (!parents.ContainsKey(neighborCell))
                {
                    continue;
                }

                var otherCell = neighborCell;

                while (true)
                {
                    var parentCell = parents[otherCell];
                    parents[otherCell] = cell;

                    if (otherCell == parentCell)
                    {
                        if (parentCell != cell)
                        {
                            result--;
                        }

                        break;
                    }

                    otherCell = parentCell;
                }
            }

            return result;
        }
    }
}
