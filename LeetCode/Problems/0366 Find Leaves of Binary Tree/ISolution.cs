using JetBrains.Annotations;

namespace LeetCode.Problems._0366_Find_Leaves_of_Binary_Tree;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> FindLeaves(TreeNode root);
}
