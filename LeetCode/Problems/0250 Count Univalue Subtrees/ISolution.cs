using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0250_Count_Univalue_Subtrees;

[PublicAPI]
public interface ISolution
{
    public int CountUnivalSubtrees(TreeNode? root);
}
