using JetBrains.Annotations;

namespace LeetCode._0145_Binary_Tree_Postorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> PostorderTraversal(TreeNode? root);
}
