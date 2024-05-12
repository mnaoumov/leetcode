using JetBrains.Annotations;

namespace LeetCode.Problems._2998_Minimum_Number_of_Operations_to_Make_X_and_Y_Equal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-121/submissions/detail/1138558793/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperationsToMakeEqual(int x, int y)
    {
        var pq = new PriorityQueue<(int num, int steps), int>();
        pq.Enqueue((x,0),0);
        var seen = new HashSet<int>();

        while (true)
        {
            var (num, steps) = pq.Dequeue();

            if (!seen.Add(num))
            {
                continue;
            }

            if (num == y)
            {
                return steps;
            }

            if (num < y)
            {
                pq.Enqueue((y, steps + y - num), steps + y - num);
                continue;
            }

            if (num % 11 == 0)
            {
                pq.Enqueue((num / 11, steps + 1), steps + 1);
            }

            if (num % 5 == 0)
            {
                pq.Enqueue((num / 5, steps + 1), steps + 1);
            }

            pq.Enqueue((num - 1, steps + 1), steps + 1);
            pq.Enqueue((num + 1, steps + 1), steps + 1);
        }
    }
}
