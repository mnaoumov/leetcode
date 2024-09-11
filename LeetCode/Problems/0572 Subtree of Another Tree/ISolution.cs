using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0572_Subtree_of_Another_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot);
}
