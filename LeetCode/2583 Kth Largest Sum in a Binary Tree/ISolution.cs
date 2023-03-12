using JetBrains.Annotations;

namespace LeetCode._2583_Kth_Largest_Sum_in_a_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public long KthLargestLevelSum(TreeNode root, int k);
}
