using JetBrains.Annotations;

namespace LeetCode.Problems._1530_Number_of_Good_Leaf_Nodes_Pairs;

[PublicAPI]
public interface ISolution
{
    public int CountPairs(TreeNode root, int distance);
}
