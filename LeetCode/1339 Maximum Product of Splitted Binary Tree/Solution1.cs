using JetBrains.Annotations;

namespace LeetCode._1339_Maximum_Product_of_Splitted_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/857351204/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProduct(TreeNode root)
    {
        var sums = new Dictionary<TreeNode, long>();

        var stack = new Stack<TreeNode?>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if (node == null)
            {
                continue;
            }

            if (sums.ContainsKey(node))
            {
                continue;
            }

            var sum = node.val + GetSum(node.left) + GetSum(node.right);

            if (sum != null)
            {
                sums[node] = sum.Value;
            }
            else
            {
                stack.Push(node);
                stack.Push(node.left);
                stack.Push(node.right);
            }
        }

        long result = int.MinValue;

        foreach (var (node, sum) in sums)
        {
            if (Equals(node, root))
            {
                continue;
            }

            result = Math.Max(result, sum * (sums[root] - sum));
        }

        return (int) (result % 1_000_000_007);

        long? GetSum(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            if (sums.ContainsKey(node))
            {
                return sums[node];
            }

            return null;
        }
    }
}
