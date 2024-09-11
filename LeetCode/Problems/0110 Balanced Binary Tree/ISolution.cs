using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0110_Balanced_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsBalanced(TreeNode? root);
}
