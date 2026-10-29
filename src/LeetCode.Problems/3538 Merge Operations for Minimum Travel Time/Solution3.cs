namespace LeetCode.Problems._3538_Merge_Operations_for_Minimum_Travel_Time;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution3 : ISolution
{
    public int MinTravelTime(int l, int n, int k, int[] position, int[] time)
    {
        var segments = new List<Segment>();

        var ans = 0;

        for (var i = 0; i < n - 1; i++)
        {
            var length = position[i + 1] - position[i];
            var pace = time[i];
            segments.Add(new Segment(length, pace));
            ans += length * pace;
        }

        segments.Add(new Segment(0, time[n - 1]));

        var pq = new PriorityQueue<(int index, int diff), int>();
        var diffs = new List<int> { 0 };

        for (var i = 1; i < n - 1; i++)
        {
            diffs.Add(CalculateDiff(i));
            pq.Enqueue((i, diffs[i]), diffs[i]);
        }

        for (var i = 0; i < k; i++)
        {
            var (index, diff) = pq.Dequeue();
            if (diffs[index] != diff)
            {
                i--;
                continue;
            }

            ans += diff;
            segments[index] = new Segment(segments[index].Length, segments[index - 1].Pace);
            segments[index + 1] =
                new Segment(segments[index + 1].Length, segments[index].Pace + segments[index + 1].Pace);

            for (var j = Math.Max(1, index - 3); j < Math.Min(index + 3, segments.Count - 2); j++)
            {
                diffs[j] = CalculateDiff(j);
                pq.Enqueue((j, diffs[j]), diffs[j]);
            }
        }

        return ans;

        int CalculateDiff(int index) =>
            segments[index].Length * (segments[index - 1].Pace - segments[index].Pace) +
            segments[index + 1].Length * segments[index].Pace;
    }
    private record Segment(int Length, int Pace);
}
