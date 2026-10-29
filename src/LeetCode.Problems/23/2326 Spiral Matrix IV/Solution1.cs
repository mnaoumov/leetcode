namespace LeetCode.Problems._2326_Spiral_Matrix_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/1384311990/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] SpiralMatrix(int m, int n, ListNode head)
    {
        const int noValue = int.MinValue;
        var ans = Enumerable.Range(0, m).Select(_ => Enumerable.Repeat(noValue, n).ToArray()).ToArray();
        var node = head;
        const int missingValue = -1;
        var cell = new Cell(0, 0);
        var direction = new Cell(0, 1);

        for (var i = 0; i < m * n; i++)
        {
            var value = node?.val ?? missingValue;
            ans[cell.Row][cell.Column] = value;
            var nextCell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column);
            if (nextCell.Row < 0 || nextCell.Row >= m || nextCell.Column < 0 || nextCell.Column >= n || ans[nextCell.Row][nextCell.Column] != noValue)
            {
                direction = new Cell(direction.Column, -direction.Row);
                nextCell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column);
            }

            cell = nextCell;
            node = node?.next;
        }

        return ans;
    }

    private record Cell(int Row, int Column);
}
