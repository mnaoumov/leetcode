using JetBrains.Annotations;

namespace LeetCode._0700_Search_in_a_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905691403/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode? SearchBST(TreeNode root, int val)
    {
        while (val != root.val)
        {
            if (val < root.val)
            {
                if (root.left == null)
                {
                    return null;
                }

                root = root.left;
                continue;
            }

            if (root.right == null)
            {
                return null;
            }

            root = root.right;
        }

        return root;
    }
}
