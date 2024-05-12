using JetBrains.Annotations;

namespace LeetCode.Problems._1372_Longest_ZigZag_Path_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/904987142/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int LongestZigZag(TreeNode root) => LongestZigZag(root, Direction.Unknown);

    private static int LongestZigZag(TreeNode? node, Direction direction) =>
        node == null
            ? -1
            : direction switch
            {
                Direction.Unknown => new[]
                {
                    LongestZigZag(node.left, Direction.Unknown),
                    LongestZigZag(node.right, Direction.Unknown),
                    LongestZigZag(node, Direction.Left),
                    LongestZigZag(node, Direction.Right)
                }.Max(),
                Direction.Left => 1 + LongestZigZag(node.left, Direction.Right),
                Direction.Right => 1 + LongestZigZag(node.right, Direction.Left),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };

    private enum Direction
    {
        Unknown,
        Left,
        Right
    }
}
