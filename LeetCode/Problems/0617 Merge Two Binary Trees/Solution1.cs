using JetBrains.Annotations;

namespace LeetCode._0617_Merge_Two_Binary_Trees;

/// <summary>
/// https://leetcode.com/submissions/detail/927590935/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? MergeTrees(TreeNode? root1, TreeNode? root2)
    {
        if (root1 == null)
        {
            return root2;
        }

        if (root2 == null)
        {
            return root1;
        }

        return new TreeNode
        {
            val = root1.val + root2.val,
            left = MergeTrees(root1.left, root2.left),
            right = MergeTrees(root1.right, root2.right)
        };
    }
}
