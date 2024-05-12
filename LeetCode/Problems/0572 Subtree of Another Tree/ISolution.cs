using JetBrains.Annotations;

namespace LeetCode._0572_Subtree_of_Another_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot);
}
