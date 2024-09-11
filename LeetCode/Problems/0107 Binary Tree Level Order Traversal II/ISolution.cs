using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0107_Binary_Tree_Level_Order_Traversal_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LevelOrderBottom(TreeNode? root);
}
