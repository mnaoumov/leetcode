using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0100_Same_Tree;

[PublicAPI]
public interface ISolution
{
    public bool IsSameTree(TreeNode p, TreeNode q);
}
