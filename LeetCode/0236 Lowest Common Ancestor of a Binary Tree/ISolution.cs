using JetBrains.Annotations;

namespace LeetCode._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q);
}