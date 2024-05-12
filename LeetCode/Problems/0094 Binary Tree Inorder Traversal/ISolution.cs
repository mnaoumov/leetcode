using JetBrains.Annotations;

namespace LeetCode.Problems._0094_Binary_Tree_Inorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> InorderTraversal(TreeNode? root);
}
