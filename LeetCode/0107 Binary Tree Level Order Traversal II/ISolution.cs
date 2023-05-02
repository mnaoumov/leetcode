using JetBrains.Annotations;

namespace LeetCode._0107_Binary_Tree_Level_Order_Traversal_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LevelOrderBottom(TreeNode? root);
}
