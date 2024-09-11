using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2583_Kth_Largest_Sum_in_a_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public long KthLargestLevelSum(TreeNode root, int k);
}
