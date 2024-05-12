using JetBrains.Annotations;

namespace LeetCode.Problems._0230_Kth_Smallest_Element_in_a_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/936757284/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KthSmallest(TreeNode root, int k) => Inorder(root).ElementAt(k - 1);

    private static IEnumerable<int> Inorder(TreeNode? node) =>
        node == null
            ? Enumerable.Empty<int>()
            : Inorder(node.left).Append(node.val).Concat(Inorder(node.right));
}
