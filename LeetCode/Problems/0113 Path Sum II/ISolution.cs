using JetBrains.Annotations;

namespace LeetCode._0113_Path_Sum_II;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum);
}
