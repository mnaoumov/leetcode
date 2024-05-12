using JetBrains.Annotations;

namespace LeetCode.Problems._1183_Maximum_Number_of_Ones;

/// <summary>
/// https://leetcode.com/submissions/detail/1034608760/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumNumberOfOnes(int width, int height, int sideLength, int maxOnes)
    {
        var pq = new PriorityQueue<int, int>();

        for (var i = 0; i < sideLength; i++)
        {
            for (var j = 0; j < sideLength; j++)
            {
                var count = (1 + (int) Math.Floor(1d * (width - 1 - i) / sideLength)) *
                            (1 + (int) Math.Floor(1d * (height - 1 - j) / sideLength));
                pq.Enqueue(count, -count);
            }
        }

        var ans = 0;

        for (var i = 0; i < maxOnes; i++)
        {
            ans += pq.Dequeue();
        }

        return ans;
    }
}
