using JetBrains.Annotations;

namespace LeetCode._0333_Largest_BST_Subtree;

/// <summary>
/// https://leetcode.com/submissions/detail/1072292232/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestBSTSubtree(TreeNode? root) => Process(root).largestBstSize;

    private static (int largestBstSize, bool isBst, int min, int max) Process(TreeNode? node)
    {
        if (node == null)
        {
            return (largestBstSize: 0, isBst: true, min: int.MinValue, max: int.MaxValue);
        }

        var leftResult = Process(node.left);
        var rightResult = Process(node.right);

        if (leftResult.isBst && rightResult.isBst && (leftResult.largestBstSize == 0 || leftResult.max < node.val) && (rightResult.largestBstSize == 0 || node.val < rightResult.min))
        {
            return (
                largestBstSize: 1 + leftResult.largestBstSize + rightResult.largestBstSize,
                isBst: true,
                min: leftResult.largestBstSize == 0 ? node.val : leftResult.min,
                max: rightResult.largestBstSize == 0 ? node.val : rightResult.max
            );
        }

        return (
            largestBstSize: Math.Max(leftResult.largestBstSize, rightResult.largestBstSize),
            isBst: false,
            min: int.MinValue,
            max: int.MaxValue
        );
    }
}
