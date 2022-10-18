using JetBrains.Annotations;

namespace LeetCode._0102_Binary_Tree_Level_Order_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LevelOrder(TreeNode root);
}