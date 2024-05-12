using JetBrains.Annotations;

namespace LeetCode.Problems._1136_Parallel_Courses;

/// <summary>
/// https://leetcode.com/submissions/detail/937161829/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinimumSemesters(int n, int[][] relations)
    {
        var adjNodes = Enumerable.Range(0, n + 1).Select(_ => new HashSet<int>()).ToArray();
        var indegrees = new int[n + 1];

        foreach (var relation in relations)
        {
            adjNodes[relation[0]].Add(relation[1]);
            indegrees[relation[1]]++;
        }

        var queue = new Queue<int>();
        var seen = new HashSet<int>();

        for (var i = 1; i <= n; i++)
        {
            if (indegrees[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        var ans = 0;

        int count;

        while ((count = queue.Count) > 0)
        {
            ans++;

            var nextNodes = new HashSet<int>();

            for (var i = 0; i < count; i++)
            {
                var node = queue.Dequeue();
                seen.Add(node);

                foreach (var adjNode in adjNodes[node])
                {
                    nextNodes.Add(adjNode);
                    indegrees[adjNode]--;
                }
            }

            foreach (var nextNode in nextNodes)
            {
                if (seen.Overlaps(adjNodes[nextNode]))
                {
                    return -1;
                }

                if (indegrees[nextNode] == 0)
                {
                    queue.Enqueue(nextNode);
                }
            }

        }

        return seen.Count == n ? ans : -1;
    }
}
