using JetBrains.Annotations;

namespace LeetCode.Problems._2265_Count_Nodes_Equal_to_Average_of_Subtree;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AverageOfSubtree(TreeNode root) => Dfs(root).countNodesEqualToAverage;

    private static (int sum, int subtreeCount, int countNodesEqualToAverage) Dfs(TreeNode? node)
    {
        if (node == null)
        {
            return (0, 0, 0);
        }

        var left = Dfs(node.left);
        var right = Dfs(node.right);

        var sum = left.sum + right.sum + node.val;
        var subtreeCount = left.subtreeCount + right.subtreeCount + 1;
        var average = sum / subtreeCount;
        var countNodesEqualToAverage =
            left.countNodesEqualToAverage
            + right.countNodesEqualToAverage
            + (average == node.val ? 1 : 0);
        return (sum, subtreeCount, countNodesEqualToAverage);

    }
}
