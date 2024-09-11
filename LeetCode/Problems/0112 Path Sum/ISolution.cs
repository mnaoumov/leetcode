using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0112_Path_Sum;

[PublicAPI]
public interface ISolution
{
    public bool HasPathSum(TreeNode? root, int targetSum);
}
