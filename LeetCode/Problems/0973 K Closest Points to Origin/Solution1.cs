using JetBrains.Annotations;

namespace LeetCode.Problems._0973_K_Closest_Points_to_Origin;

/// <summary>
/// https://leetcode.com/submissions/detail/908084079/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] KClosest(int[][] points, int k)
    {
        var heap = new PriorityQueue<int[], int>();

        foreach (var point in points)
        {
            heap.Enqueue(point, -Sqr(point[0]) - Sqr(point[1]));

            if (heap.Count == k + 1)
            {
                heap.Dequeue();
            }
        }

        var result = new int[k][];

        for (var i = 0; i < k; i++)
        {
            result[i] = heap.Dequeue();
        }

        return result;
    }

    private static int Sqr(int x) => x * x;
}
