using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0105_Construct_Binary_Tree_from_Preorder_and_Inorder_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/830070489/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        return Build(0, 0, preorder.Length)!;

        TreeNode? Build(int preorderIndex, int inorderIndex, int count)
        {
            if (count == 0)
            {
                return null;
            }

            var value = preorder[preorderIndex];

            var leftTreeCount = 0;

            while (inorder[inorderIndex + leftTreeCount] != value)
            {
                leftTreeCount++;
            }

            return new TreeNode
            {
                val = value,
                left = Build(preorderIndex + 1, inorderIndex, leftTreeCount),
                right = Build(preorderIndex + 1 + leftTreeCount, inorderIndex + 1 + leftTreeCount,
                    count - leftTreeCount - 1)
            };
        }
    }
}
