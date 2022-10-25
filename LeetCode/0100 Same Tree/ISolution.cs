using JetBrains.Annotations;

namespace LeetCode._0100_Same_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsSameTree(TreeNode p, TreeNode q);
}