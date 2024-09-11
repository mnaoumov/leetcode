using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1740_Find_Distance_in_a_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public int FindDistance(TreeNode root, int p, int q);
}
