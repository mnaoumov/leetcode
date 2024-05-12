using JetBrains.Annotations;

namespace LeetCode._0378_Kth_Smallest_Element_in_a_Sorted_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/956288694/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var pq = new PriorityQueue<int, int>();

        var n = matrix.Length;

        for (var s = 0; s <= k; s++)
        {
            for (var i = Math.Max(0, s - n + 1); i <= Math.Min(s, n - 1); i++)
            {
                var j = s - i;
                var num = matrix[i][j];
                pq.Enqueue(num, -num);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
        }

        return pq.Dequeue();
    }
}
