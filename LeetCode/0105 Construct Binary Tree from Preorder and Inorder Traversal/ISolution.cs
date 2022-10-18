using JetBrains.Annotations;

namespace LeetCode._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public TreeNode BuildTree(int[] preorder, int[] inorder);
}