namespace LeetCode.Problems._0145_Binary_Tree_Postorder_Traversal;

/// <summary>
/// https://leetcode.com/problems/binary-tree-postorder-traversal/submissions/845330020/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> PostorderTraversal(TreeNode? root) => Enumerate(root).ToArray();

    private static IEnumerable<int> Enumerate(TreeNode? node) => node == null
        ? Enumerable.Empty<int>()
        : Enumerate(node.left).Concat(Enumerate(node.right)).Append(node.val);
}
