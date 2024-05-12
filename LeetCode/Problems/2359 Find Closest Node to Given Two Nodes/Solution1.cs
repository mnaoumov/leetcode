using JetBrains.Annotations;

namespace LeetCode.Problems._2359_Find_Closest_Node_to_Given_Two_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/884770760/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int ClosestMeetingNode(int[] edges, int node1, int node2)
    {
        var n = edges.Length;

        const int unreachable = -1;

        var distances1 = Enumerable.Repeat(unreachable, n).ToArray();
        var distances2 = Enumerable.Repeat(unreachable, n).ToArray();

        FillDistances(node1, distances1);
        FillDistances(node2, distances2);

        var minMaxDistance = int.MaxValue;
        var result = unreachable;

        for (var node = 0; node < n; node++)
        {
            if (distances1[node] == unreachable || distances2[node] == unreachable)
            {
                continue;
            }

            var maxDistance = Math.Max(distances1[node], distances2[node]);

            if (maxDistance >= minMaxDistance)
            {
                continue;
            }

            minMaxDistance = maxDistance;
            result = node;
        }

        return result;

        void FillDistances(int node, IList<int> distances)
        {
            var distance = 0;
            while (node != unreachable)
            {
                distances[node] = distance;
                node = edges[node];
                distance++;
            }
        }
    }
}
