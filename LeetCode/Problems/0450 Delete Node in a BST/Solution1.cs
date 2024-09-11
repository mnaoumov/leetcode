namespace LeetCode.Problems._0450_Delete_Node_in_a_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/906182878/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public TreeNode? DeleteNode(TreeNode? root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val == key)
        {
            if (root.left != null)
            {
                if (root.left.right == null)
                {
                    root.val = root.left.val;
                    root.left = root.left.left;
                    return root;
                }

                var parentOfRightmost = root.left;

                while (parentOfRightmost.right!.right != null)
                {
                    parentOfRightmost = parentOfRightmost.right;
                }

                root.val = parentOfRightmost.right.val;
                parentOfRightmost.right = null;
                return root;
            }

            if (root.right == null)
            {
                return null;
            }

            if (root.right.left == null)
            {
                root.val = root.right.val;
                root.right = root.right.right;
                return root;
            }

            var parentOfLeftmost = root.right;

            while (parentOfLeftmost.left!.left != null)
            {
                parentOfLeftmost = parentOfLeftmost.left;
            }

            root.val = parentOfLeftmost.left.val;
            parentOfLeftmost.left = null;
            return root;

        }

        if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
            return root;
        }

        root.right = DeleteNode(root.right, key);
        return root;
    }
}
