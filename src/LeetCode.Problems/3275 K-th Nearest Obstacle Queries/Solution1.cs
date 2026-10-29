namespace LeetCode.Problems._3275_K_th_Nearest_Obstacle_Queries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-413/submissions/detail/1374800313/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ResultsArray(int[][] queries, int k)
    {
        var n = queries.Length;
        var ans = new int[n];

        var pq = new PriorityQueue<int, int>();

        for (var i = 0; i < queries.Length; i++)
        {
            var query = queries[i];
            var x = query[0];
            var y = query[1];
            var distance = Math.Abs(x) + Math.Abs(y);
            pq.Enqueue(distance, -distance);

            if (pq.Count > k)
            {
                pq.Dequeue();
            }

            ans[i] = pq.Count < k ? -1 : pq.Peek();
        }


        return ans;
    }
}
