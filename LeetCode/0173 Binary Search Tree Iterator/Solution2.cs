using JetBrains.Annotations;

namespace LeetCode._0173_Binary_Search_Tree_Iterator;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IBSTIterator Create(TreeNode root)
    {
        return new BSTIterator2(root);
    }
}