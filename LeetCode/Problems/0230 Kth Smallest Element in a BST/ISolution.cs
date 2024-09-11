using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0230_Kth_Smallest_Element_in_a_BST;

[PublicAPI]
public interface ISolution
{
    public int KthSmallest(TreeNode root, int k);
}
