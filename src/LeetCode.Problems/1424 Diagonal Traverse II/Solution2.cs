namespace LeetCode.Problems._1424_Diagonal_Traverse_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1103824685/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] FindDiagonalOrder(IList<IList<int>> nums)
    {
        var pq = new PriorityQueue<(int row, int column), (int rowColumnSum, int inverseRow)>();

        for (var row = 0; row < nums.Count; row++)
        {
            for (var column = 0; column < nums[row].Count; column++)
            {
                pq.Enqueue((row, column), (rowColumnSum: row + column, inverseRow: -row));
            }
        }

        var ans = new int[pq.Count];

        var i = 0;

        while (pq.Count > 0)
        {
            var (row, column) = pq.Dequeue();
            ans[i] = nums[row][column];
            i++;
        }

        return ans;
    }
}
