using JetBrains.Annotations;

namespace LeetCode._0701_Insert_into_a_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/897382173/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode InsertIntoBST(TreeNode? root, int val)
    {
        if (root == null)
        {
            return new TreeNode(val);
        }

        if (root.val < val)
        {
            root.right = InsertIntoBST(root.right, val);
        }
        else
        {
            root.left = InsertIntoBST(root.left, val);
        }

        return root;
    }
}
