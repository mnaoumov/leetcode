using JetBrains.Annotations;

namespace LeetCode._0144_Binary_Tree_Preorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> PreorderTraversal(TreeNode? root);
}
