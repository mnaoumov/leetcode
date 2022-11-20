using JetBrains.Annotations;

namespace LeetCode._2476_Closest_Nodes_Queries_in_a_Binary_Search_Tree;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> ClosestNodes(TreeNode root, IList<int> queries);
}
