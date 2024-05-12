using JetBrains.Annotations;

namespace LeetCode._0786_K_th_Smallest_Prime_Fraction;

/// <summary>
/// https://leetcode.com/submissions/detail/1254782204/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
        var pq = new PriorityQueue<int[], double>();

        var n = arr.Length;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                pq.Enqueue(new[] { arr[i], arr[j] }, -1d * arr[i] / arr[j]);

                if (pq.Count > k)
                {
                    pq.Dequeue();
                }
            }
        }

        return pq.Dequeue();
    }
}
