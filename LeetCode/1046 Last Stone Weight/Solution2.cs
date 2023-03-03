using JetBrains.Annotations;

namespace LeetCode._1046_Last_Stone_Weight;

/// <summary>
/// https://leetcode.com/submissions/detail/907458057/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LastStoneWeight(int[] stones)
    {
        var heap = new PriorityQueue<int, int>();

        foreach (var stone in stones)
        {
            heap.Enqueue(stone, -stone);
        }

        while (heap.Count > 1)
        {
            var y = heap.Dequeue();
            var x = heap.Dequeue();

            if (x < y)
            {
                heap.Enqueue(y - x, x - y);
            }
        }

        return heap.TryDequeue(out var result, out _) ? result : 0;
    }
}
