using JetBrains.Annotations;

namespace LeetCode._0173_Binary_Search_Tree_Iterator;

[PublicAPI]
public interface ISolution
{
    public IBSTIterator Create(TreeNode root);
}
