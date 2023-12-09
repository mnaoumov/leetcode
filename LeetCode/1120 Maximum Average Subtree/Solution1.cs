using JetBrains.Annotations;

namespace LeetCode._1120_Maximum_Average_Subtree;

/// <summary>
/// https://leetcode.com/submissions/detail/1115382811/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double MaximumAverageSubtree(TreeNode root)
    {
        var ans = double.MinValue;

        Dfs(root);

        return ans;

        (int subtreeSum, int subtreeCount) Dfs(TreeNode? node)
        {
            if (node == null)
            {
                return (0, 0);
            }

            #pragma warning disable IDE0042
            var left = Dfs(node.left);
            var right = Dfs(node.right);
            #pragma warning restore IDE0042

            var sum = left.subtreeSum + right.subtreeSum + node.val;
            var count = left.subtreeCount + right.subtreeCount + 1;

            var avg = 1d * sum / count;
            ans = Math.Max(ans, avg);

            return (sum, count);
        }
    }
}
