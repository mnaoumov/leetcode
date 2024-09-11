namespace LeetCode.Problems._1361_Validate_Binary_Tree_Nodes;

/// <summary>
/// https://leetcode.com/submissions/detail/1077125147/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

        var seen = new HashSet<int>();
        return Dfs(root) && seen.Count == n;

        bool Dfs(int node)
        {
            if (node == -1)
            {
                return true;
            }

            if (!seen.Add(node))
            {
                return false;
            }

            return Dfs(leftChild[node]) && Dfs(rightChild[node]);
        }
    }
}
