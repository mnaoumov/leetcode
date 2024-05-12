using JetBrains.Annotations;

namespace LeetCode.Problems._1325_Delete_Leaves_With_a_Given_Value;

/// <summary>
/// https://leetcode.com/submissions/detail/904942183/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode RemoveLeafNodes(TreeNode root, int target)
    {
        return Remove(root)!;

        TreeNode? Remove(TreeNode? treeNode)
        {
            if (treeNode == null)
            {
                return null;
            }

            var result = new TreeNode
            {
                val = treeNode.val,
                left = Remove(treeNode.left),
                right = Remove(treeNode.right)
            };

            return result.val == target && result.left == null && result.right == null ? null : result;
        }
    }
}
