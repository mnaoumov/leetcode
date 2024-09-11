using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0144_Binary_Tree_Preorder_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<int> PreorderTraversal(TreeNode? root);
}
