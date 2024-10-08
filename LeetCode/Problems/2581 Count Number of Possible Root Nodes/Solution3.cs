namespace LeetCode.Problems._2581_Count_Number_of_Possible_Root_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/909204408/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int RootCount(int[][] edges, int[][] guesses, int k)
    {
        var n = edges.Length + 1;

        var adjacentNodes = Enumerable.Range(0, n).Select(_ => new HashSet<int>()).ToArray();

        foreach (var edge in edges)
        {
            adjacentNodes[edge[0]].Add(edge[1]);
            adjacentNodes[edge[1]].Add(edge[0]);
        }

        var guessSet = guesses.Select(guess => (from: guess[0], to: guess[1])).ToHashSet();

        var zeroRootedValidGuessCount = 0;
        var parents = new int[n];

        FillParents(0, -1);

        for (var i = 1; i < n; i++)
        {
            if (guessSet.Contains((parents[i], i)))
            {
                zeroRootedValidGuessCount++;
            }
        }

        var result = 0;

        Dfs(0, -1, zeroRootedValidGuessCount);

        return result;

        void Dfs(int node, int parent, int parentRootedValidGuessCount)
        {
            if (guessSet.Contains((parent, node)))
            {
                parentRootedValidGuessCount--;
            }

            if (guessSet.Contains((node, parent)))
            {
                parentRootedValidGuessCount++;
            }

            if (parentRootedValidGuessCount >= k)
            {
                result++;
            }

            foreach (var childNode in adjacentNodes[node].Except(new[] { parent }))
            {
                Dfs(childNode, node, parentRootedValidGuessCount);
            }
        }

        void FillParents(int node, int parent)
        {
            parents[node] = parent;

            foreach (var childNode in adjacentNodes[node].Except(new[] { parent }))
            {
                FillParents(childNode, node);
            }
        }
    }
}
