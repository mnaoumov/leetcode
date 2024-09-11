namespace LeetCode.Problems._1337_The_K_Weakest_Rows_in_a_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/928129478/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var pq = new PriorityQueue<int, (int reverseSoldiersCount, int reverseIndex)>();

        for (var i = 0; i < m; i++)
        {
            var low = 0;
            var high = n - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (mat[i][mid] == 0)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            pq.Enqueue(i, (-low, -i));

            if (pq.Count > k)
            {
                pq.Dequeue();
            }
        }

        var result = new int[k];

        for (var i = 0; i < k; i++)
        {
            result[k - 1 - i] = pq.Dequeue();
        }

        return result;
    }
}
