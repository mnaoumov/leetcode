using JetBrains.Annotations;

namespace LeetCode.Problems._1167_Minimum_Cost_to_Connect_Sticks;

/// <summary>
/// https://leetcode.com/submissions/detail/908031111/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ConnectSticks(int[] sticks)
    {
        var heap = new PriorityQueue<int, int>(sticks.Select(stick => (stick, stick)));
        var result = 0;

        while (heap.Count > 1)
        {
            var shortestStick1 = heap.Dequeue();
            var shortestStick2 = heap.Dequeue();
            var newStick = shortestStick1 + shortestStick2;
            result += newStick;
            heap.Enqueue(newStick, newStick);
        }

        return result;
    }
}
