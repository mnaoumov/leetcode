using JetBrains.Annotations;

namespace LeetCode.Problems._2246_Longest_Path_With_Different_Adjacent_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/877227894/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LongestPath(int[] parent, string s)
    {
        var n = parent.Length;
        var children = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var node = 1; node < n; node++)
        {
            children[parent[node]].Add(node);
        }

        var result = 0;
        Dfs(0);

        return result;

        int Dfs(int node)
        {
            var maxChildrenRootPathLengths = new PriorityQueue<int, int>();

            int maxRootPathLength;

            foreach (var child in children[node])
            {
                maxRootPathLength = Dfs(child);

                if (s[node] == s[child])
                {
                    continue;
                }

                maxChildrenRootPathLengths.Enqueue(maxRootPathLength, maxRootPathLength);

                if (maxChildrenRootPathLengths.Count > 2)
                {
                    maxChildrenRootPathLengths.Dequeue();
                }
            }

            var maxCombinedPathLength = 1;

            maxRootPathLength = 0;

            while (maxChildrenRootPathLengths.Count > 0)
            {
                maxRootPathLength = maxChildrenRootPathLengths.Dequeue();
                maxCombinedPathLength += maxRootPathLength;
            }

            result = Math.Max(result, maxCombinedPathLength);
            return maxRootPathLength + 1;
        }
    }
}
