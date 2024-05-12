using JetBrains.Annotations;

namespace LeetCode.Problems._0235_Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q);
}
