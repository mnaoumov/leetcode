using JetBrains.Annotations;

namespace LeetCode.Problems._0437_Path_Sum_III;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int PathSum(TreeNode? root, int targetSum) => PathSum(root, targetSum, false);

    private static int PathSum(TreeNode? node, long targetSum, bool isParentIncluded)
    {
        if (node == null)
        {
            return 0;
        }

        var result = node.val == targetSum ? 1 : 0;

        result += PathSum(node.left, targetSum - node.val, true);
        result += PathSum(node.right, targetSum - node.val, true);

        if (isParentIncluded)
        {
            return result;
        }

        result += PathSum(node.left, targetSum, false);
        result += PathSum(node.right, targetSum, false);

        return result;
    }
}
