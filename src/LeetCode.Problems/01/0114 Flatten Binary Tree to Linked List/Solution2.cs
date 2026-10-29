namespace LeetCode.Problems._0114_Flatten_Binary_Tree_to_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/834091869/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public void Flatten(TreeNode? root)
    {
        Process(root);
    }

    private static void Process(TreeNode? node)
    {
        while (node != null)
        {
            if (node.left != null)
            {
                var rightmost = GetRightmost(node.left);
                (node.left, node.right, rightmost.right) = (null, node.left, node.right);
            }

            node = node.right;
        }
    }

    private static TreeNode GetRightmost(TreeNode node)
    {
        while (true)
        {
            if (node.right == null)
            {
                return node;
            }

            node = node.right;
        }
    }
}
