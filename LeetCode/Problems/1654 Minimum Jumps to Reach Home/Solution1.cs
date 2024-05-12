using JetBrains.Annotations;

namespace LeetCode._1654_Minimum_Jumps_to_Reach_Home;

/// <summary>
/// https://leetcode.com/submissions/detail/928685663/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        var queue = new Queue<(int position, bool wasPreviousJumpForward)>();
        queue.Enqueue((0, true));
        var result = 0;
        var seen = forbidden.ToHashSet();

        int count;

        while ((count = queue.Count) > 0)
        {
            for (var i = 0; i < count; i++)
            {
                var (position, wasPreviousJumpForward) = queue.Dequeue();

                if (!seen.Add(position))
                {
                    continue;
                }

                if (position < 0)
                {
                    continue;
                }

                if (position == x)
                {
                    return result;
                }

                if (position > x + b)
                {
                    continue;
                }

                queue.Enqueue((position + a, true));

                if (wasPreviousJumpForward)
                {
                    queue.Enqueue((position - b, false));
                }
            }

            result++;
        }

        return -1;
    }
}
