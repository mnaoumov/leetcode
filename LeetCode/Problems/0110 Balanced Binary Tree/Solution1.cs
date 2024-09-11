namespace LeetCode.Problems._0110_Balanced_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/830300002/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsBalanced(TreeNode? root)
    {
        var heightDict = new Dictionary<TreeNode, int>();

        return IsBalancedImpl(root);

        bool IsBalancedImpl(TreeNode? node)
        {
            if (node == null)
            {
                return true;
            }

            return Math.Abs(GetHeight(node.left) - GetHeight(node.right)) <= 1 && IsBalancedImpl(node.left) && IsBalancedImpl(node.right);
        }

        int GetHeight(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            if (!heightDict.TryGetValue(node, out var height))
            {
                heightDict[node] = height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
            }

            return height;
        }
    }
}
