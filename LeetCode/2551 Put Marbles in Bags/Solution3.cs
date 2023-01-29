using JetBrains.Annotations;

namespace LeetCode._2551_Put_Marbles_in_Bags;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887206701/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long PutMarbles(int[] weights, int k)
    {
        var maxNeighborSums = new PriorityQueue<int, int>();
        var minNeighborSums = new PriorityQueue<int, int>();
        var result = 0L;

        for (var i = 0; i < weights.Length - 1; i++)
        {
            var sum = weights[i] + weights[i + 1];
            maxNeighborSums.Enqueue(sum, sum);
            minNeighborSums.Enqueue(sum, -sum);
            
            if (i < k - 1)
            {
                continue;
            }

            result -= maxNeighborSums.Dequeue();
            result += minNeighborSums.Dequeue();
        }

        return result;
    }
}
