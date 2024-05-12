using JetBrains.Annotations;

namespace LeetCode.Problems._1921_Eliminate_Maximum_Number_of_Monsters;

/// <summary>
/// https://leetcode.com/submissions/detail/1093994201/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var n = dist.Length;
        var times = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            var time = (dist[i] + speed[i] - 1) / speed[i];
            times.Enqueue(time, time);
        }

        var ans = 0;

        while (times.Count > 0)
        {
            var time = times.Dequeue();

            if (time <= ans)
            {
                break;
            }

            ans++;
        }

        return ans;
    }
}
