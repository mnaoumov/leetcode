using JetBrains.Annotations;

namespace LeetCode.Problems._0776_Split_BST;

/// <summary>
/// https://leetcode.com/submissions/detail/1303418214/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode?[] SplitBST(TreeNode? root, int target)
    {
        var smallerOrEqualRootParent = new TreeNode(int.MinValue);
        var greaterRootParent = new TreeNode(int.MaxValue);

        Traverse(root, smallerOrEqualRootParent, greaterRootParent);

        return new[] { smallerOrEqualRootParent.right, greaterRootParent.left };

        void Traverse(TreeNode? treeNode, TreeNode smallerOrEqualNode, TreeNode greaterNode)
        {
            if (treeNode == null)
            {
                return;
            }

            var newNode = new TreeNode(treeNode.val);

            TreeNode nextSmallerOrEqualNode;
            TreeNode nextGreaterNode;
            TreeNode parentNode;

            if (treeNode.val <= target)
            {
                parentNode = smallerOrEqualNode;
                nextSmallerOrEqualNode = newNode;
                nextGreaterNode = greaterNode;
            }
            else
            {
                parentNode = greaterNode;
                nextSmallerOrEqualNode = smallerOrEqualNode;
                nextGreaterNode = newNode;
            }

            if (treeNode.val < parentNode.val)
            {
                parentNode.left = newNode;
            }
            else
            {
                parentNode.right = newNode;
            }

            Traverse(treeNode.left, nextSmallerOrEqualNode, nextGreaterNode);
            // ReSharper disable once TailRecursiveCall
            Traverse(treeNode.right, nextSmallerOrEqualNode, nextGreaterNode);
        }
    }
}
