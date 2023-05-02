using JetBrains.Annotations;

namespace LeetCode._2246_Longest_Path_With_Different_Adjacent_Characters;

/// <summary>
/// https://leetcode.com/submissions/detail/877161855/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestPath(int[] parent, string s)
    {
        var n = parent.Length;
        var children = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var node = 1; node < parent.Length; node++)
        {
            children[parent[node]].Add(node);
        }

        var result = 0;
        Dfs(0);

        int Dfs(int node)
        {
            var maxChildrenRootPathLengths = new PriorityQueue<int, int>();

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var child in children[node])
            {
                var maxRootPathLength = Dfs(child);

                if (s[node] == s[child])
                {
                    continue;
                }

                maxChildrenRootPathLengths.Enqueue(maxRootPathLength, -maxRootPathLength);

                if (maxChildrenRootPathLengths.Count > 2)
                {
                    maxChildrenRootPathLengths.Dequeue();
                }
            }

            var maxChildRootPathLength = maxChildrenRootPathLengths.TryDequeue(out var x, out _) ? x : 0;
            var nextMaxChildRootPathLength = maxChildrenRootPathLengths.TryDequeue(out var y, out _) ? y : 0;
            result = Math.Max(result, maxChildRootPathLength + nextMaxChildRootPathLength + 1);
            return maxChildRootPathLength + 1;
        }

        return result;
    }
}
