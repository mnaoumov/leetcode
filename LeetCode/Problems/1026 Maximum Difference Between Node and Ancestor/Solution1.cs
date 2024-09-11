namespace LeetCode.Problems._1026_Maximum_Difference_Between_Node_and_Ancestor;

/// <summary>
/// https://leetcode.com/submissions/detail/856881642/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxAncestorDiff(TreeNode root)
    {
        var minDescendantValues = new Dictionary<TreeNode, int?>();
        var maxDescendantValues = new Dictionary<TreeNode, int?>();

        var result = 0;

        Dfs(root);

        return result;

        void Dfs(TreeNode? node)
        {
            while (node != null)
            {
                if (GetMinDescendantValue(node) is { } min)
                {
                    result = Math.Max(result, Math.Abs(node.val - min));
                }

                if (GetMaxDescendantValue(node) is { } max)
                {
                    result = Math.Max(result, Math.Abs(node.val - max));
                }

                Dfs(node.left);
                node = node.right;
            }
        }

        int? GetMinDescendantValue(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (minDescendantValues.TryGetValue(node, out var value))
            {
                return value;
            }

            return minDescendantValues[node] =
                new[]
                {
                    node.left?.val,
                    node.right?.val,
                    GetMinDescendantValue(node.left),
                    GetMinDescendantValue(node.right)
                }.Where(x => x != null).DefaultIfEmpty(null).Min();
        }

        int? GetMaxDescendantValue(TreeNode? node)
        {
            if (node == null)
            {
                return null;
            }

            if (maxDescendantValues.TryGetValue(node, out var value))
            {
                return value;
            }


            return maxDescendantValues[node] = new[]
            {
                node.left?.val,
                node.right?.val,
                GetMaxDescendantValue(node.left),
                GetMaxDescendantValue(node.right)
            }.Where(x => x != null).DefaultIfEmpty(null).Max();
        }
    }
}
