using JetBrains.Annotations;

namespace LeetCode._2246_Longest_Path_With_Different_Adjacent_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/877218814/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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

        int Dfs(int node)
        {
            var maxChildrenRootPathLengths = new PriorityQueue<int, int>();

            var maxRootPathLength = 0;

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

            while (maxChildrenRootPathLengths.Count > 0)
            {
                maxRootPathLength = maxChildrenRootPathLengths.Dequeue();
                maxCombinedPathLength += maxRootPathLength;
            }

            result = Math.Max(result, maxCombinedPathLength);
            return maxRootPathLength + 1;
        }

        return result;
    }
}
