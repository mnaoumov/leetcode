using JetBrains.Annotations;

namespace LeetCode._1361_Validate_Binary_Tree_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/1077121726/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    {
        var roots = Enumerable.Range(0, n).ToHashSet();
        roots.ExceptWith(leftChild);
        roots.ExceptWith(rightChild);

        if (roots.Count != 1)
        {
            return false;
        }

        var root = roots.Single();

        var seen = new bool[n];
        return Dfs(root);

        bool Dfs(int node)
        {
            if (node == -1)
            {
                return true;
            }

            if (seen[node])
            {
                return false;
            }

            seen[node] = true;
            return Dfs(leftChild[node]) && Dfs(rightChild[node]);
        }
    }
}
