using JetBrains.Annotations;

namespace LeetCode.Problems._0253_Meeting_Rooms_II;

/// <summary>
/// https://leetcode.com/submissions/detail/954788256/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinMeetingRooms(int[][] intervals)
    {
        var intervalObjs = intervals.Select(i => (start: i[0], end: i[1])).OrderBy(i => i.start).ToArray();

        var ans = 0;

        var stack = new Stack<(int start, int end)>();

        foreach (var (start, end) in intervalObjs)
        {
            while (stack.Count > 0 && stack.Peek().end <= start)
            {
                stack.Pop();
            }

            if (stack.Count > 0)
            {
                var lastInterval = stack.Peek();
                var intersect = (start: Math.Max(start, lastInterval.start), end: Math.Min(end, lastInterval.end));

                if (intersect.start < intersect.end)
                {
                    stack.Push(intersect);
                }
            }
            else
            {
                stack.Push((start, end));
            }

            ans = Math.Max(ans, stack.Count);
        }

        return ans;
    }
}
