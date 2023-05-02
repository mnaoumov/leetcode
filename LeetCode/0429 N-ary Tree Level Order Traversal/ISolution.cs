using JetBrains.Annotations;

namespace LeetCode._0429_N_ary_Tree_Level_Order_Traversal;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> LevelOrder(Node? root);
}
