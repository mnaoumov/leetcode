using JetBrains.Annotations;

namespace LeetCode._2872_Maximum_Number_of_K_Divisible_Components;

/// <summary>
/// https://leetcode.com/submissions/detail/1063230145/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
    {
        var adjNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjNodes[edge[0]].Add(edge[1]);
            adjNodes[edge[1]].Add(edge[0]);
        }

        var childNodes = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();
        var seen = new bool[n];

        FillChildNodesDfs(0);

        var subtreeSumMods = new int[n];


        seen = new bool[n];
        FillSubtreeSumModsDfs(0);

        var ans = 0;
        seen = new bool[n];
        CalculateAnswerDfs(0);

        return ans;

        void FillChildNodesDfs(int node)
        {
            seen[node] = true;
            foreach (var adjNode in adjNodes[node].Where(adjNode => !seen[adjNode]))
            {
                childNodes[node].Add(adjNode);
                FillChildNodesDfs(adjNode);
            }
        }

        void FillSubtreeSumModsDfs(int node)
        {
            seen[node] = true;
            subtreeSumMods[node] = values[node] % k;

            foreach (var adjNode in adjNodes[node].Where(adjNode => !seen[adjNode]))
            {
                FillSubtreeSumModsDfs(adjNode);
                subtreeSumMods[node] = (subtreeSumMods[node] + subtreeSumMods[adjNode]) % k;
            }
        }

        void CalculateAnswerDfs(int node)
        {
            if (subtreeSumMods[node] == 0)
            {
                ans++;
            }

            foreach (var childNode in childNodes[node])
            {
                CalculateAnswerDfs(childNode);
            }
        }
    }
}
