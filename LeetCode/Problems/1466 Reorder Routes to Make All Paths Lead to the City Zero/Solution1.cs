using JetBrains.Annotations;

namespace LeetCode.Problems._1466_Reorder_Routes_to_Make_All_Paths_Lead_to_the_City_Zero;

/// <summary>
/// https://leetcode.com/submissions/detail/904442641/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinReorder(int n, int[][] connections)
    {
        var next = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var previous = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var connection in connections)
        {
            next[connection[0]].Add(connection[1]);
            previous[connection[1]].Add(connection[0]);
        }

        var queue = new Queue<(int node, bool shouldReorient)>();
        queue.Enqueue((0, false));

        var seen = new HashSet<int>();

        var result = 0;

        while (queue.Count > 0)
        {
            var (node, shouldReorient) = queue.Dequeue();

            if (!seen.Add(node))
            {
                continue;
            }

            if (shouldReorient)
            {
                result++;
            }

            foreach (var previousNode in previous[node])
            {
                queue.Enqueue((previousNode, false));
            }

            foreach (var nextNode in next[node])
            {
                queue.Enqueue((nextNode, true));
            }
        }

        return result;
    }
}
