namespace LeetCode.Problems._3604_Minimum_Time_to_Reach_Destination_in_Directed_Graph;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-160/problems/minimum-time-to-reach-destination-in-directed-graph/submissions/1687421431/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinTime(int n, int[][] edges)
    {
        var edgeObjs = edges.Select(arr => new Edge(arr[0], arr[1], arr[2], arr[3])).ToArray();

        var map = new Dictionary<int, Dictionary<int, List<Interval>>>();

        foreach (var edge in edgeObjs)
        {
            map.TryAdd(edge.From, new Dictionary<int, List<Interval>>());
            map[edge.From].TryAdd(edge.To, new List<Interval>());
            map[edge.From][edge.To].Add(new Interval(edge.StartTime, edge.EndTime));
        }

        var queue = new PriorityQueue<(int node, HashSet<int> previousNodes, int time), int>();
        queue.Enqueue((0, new HashSet<int>(), 0), 0);

        while (queue.Count > 0)
        {
            var (node, previousNodes, time) = queue.Dequeue();
            if (node == n - 1)
            {
                return time;
            }

            var map2 = map.GetValueOrDefault(node, new Dictionary<int, List<Interval>>());

            foreach (var (node2, intervals) in map2)
            {
                if (previousNodes.Contains(node2))
                {
                    continue;
                }
                foreach (var interval in intervals)
                {
                    var previousNodes2 = new HashSet<int>(previousNodes) { node };

                    if (time < interval.start)
                    {
                        queue.Enqueue((node2, previousNodes2, interval.start + 1), interval.start + 1);
                    }
                    else if (time <= interval.end)
                    {
                        queue.Enqueue((node2, previousNodes2, time + 1), time + 1);
                    }
                }
            }
        }

        return -1;
    }

    private record Edge(int From, int To, int StartTime, int EndTime);

    private class Interval
    {
        // ReSharper disable once InconsistentNaming
        public readonly int start;
        // ReSharper disable once InconsistentNaming
        public readonly int end;

        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        private bool Equals(DataStructure.Interval other) => start == other.start && end == other.end;

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((DataStructure.Interval) obj);
        }

        // ReSharper disable NonReadonlyMemberInGetHashCode
        public override int GetHashCode() => HashCode.Combine(start, end);
        // ReSharper restore NonReadonlyMemberInGetHashCode
    }
}
