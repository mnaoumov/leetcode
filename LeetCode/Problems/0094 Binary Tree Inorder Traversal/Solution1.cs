using JetBrains.Annotations;

namespace LeetCode.Problems._0094_Binary_Tree_Inorder_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/829144304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> InorderTraversal(TreeNode? root)
    {
        var stack = new Stack<TreeNode?>();
        var result = new List<int>();

        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Pop();

            if (node == null)
            {
                continue;
            }

            if (node.left == null && node.right == null)
            {
                result.Add(node.val);
            }
            else
            {
                stack.Push(node.right);
                stack.Push(new TreeNode(node.val));
                stack.Push(node.left);
            }
        }

        return result;
    }
}
