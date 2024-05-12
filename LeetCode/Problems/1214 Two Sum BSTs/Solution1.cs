using JetBrains.Annotations;

namespace LeetCode.Problems._1214_Two_Sum_BSTs;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool TwoSumBSTs(TreeNode root1, TreeNode root2, int target)
    {
        var bst1 = new BinarySearchTree(root1);
        var bst2 = new BinarySearchTree(root2);

        var order2Set = bst2.Inorder().ToHashSet();
        return bst1.Inorder().Any(num1 => order2Set.Contains(target - num1));
    }

    private class BinarySearchTree
    {
        private readonly TreeNode _root;

        public BinarySearchTree(TreeNode root) => _root = root;

        public IEnumerable<int> Inorder() => Inorder(_root);

        private static IEnumerable<int> Inorder(TreeNode? node) => node == null
            ? Enumerable.Empty<int>()
            : Inorder(node.left).Append(node.val).Concat(Inorder(node.right));
    }
}
