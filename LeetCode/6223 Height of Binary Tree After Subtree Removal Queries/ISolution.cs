using JetBrains.Annotations;

namespace LeetCode._6223_Height_of_Binary_Tree_After_Subtree_Removal_Queries;

[PublicAPI]
public interface ISolution
{
    public int[] TreeQueries(TreeNode root, int[] queries);
}
