using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0106_Construct_Binary_Tree_from_Inorder_and_Postorder_Traversal;

/// <summary>
/// https://leetcode.com/submissions/detail/830105735/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        return Build(0, postorder.Length - 1, inorder.Length)!;

        TreeNode? Build(int inorderIndex, int postOrderIndex, int count)
        {
            if (count == 0)
            {
                return null;
            }

            var value = postorder[postOrderIndex];

            var leftTreeCount = 0;

            while (inorder[inorderIndex + leftTreeCount] != value)
            {
                leftTreeCount++;
            }

            return new TreeNode
            {
                val = value,
                left = Build(inorderIndex, postOrderIndex - count + leftTreeCount, leftTreeCount),
                right = Build(inorderIndex + 1 + leftTreeCount, postOrderIndex - 1, count - leftTreeCount - 1)
            };
        }
    }
}
