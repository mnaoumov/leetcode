using JetBrains.Annotations;

namespace LeetCode._0173_Binary_Search_Tree_Iterator;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IBSTIterator Create(TreeNode root)
    {
        return new BSTIterator1(root);
    }
}