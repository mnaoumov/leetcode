using JetBrains.Annotations;

namespace LeetCode._1372_Longest_ZigZag_Path_in_a_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/905492057/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int LongestZigZag(TreeNode root)
    {
        var stack = new Stack<(TreeNode? node, Direction direction, bool isCalculated)>();
        stack.Push((root, Direction.Unknown, false));
        var results = new Stack<int>();

        while (stack.Count > 0)
        {
            var key = stack.Pop();
            var (node, direction, isCalculated) = key;

            if (node == null)
            {
                results.Push(-1);
                continue;
            }

            if (!isCalculated)
            {
                stack.Push((node, direction, true));
            }

            switch (direction)
            {
                case Direction.Unknown:
                    if (!isCalculated)
                    {
                        stack.Push((node.left, Direction.Unknown, false));
                        stack.Push((node.right, Direction.Unknown, false));
                        stack.Push((node, Direction.Left, false));
                        stack.Push((node, Direction.Right, false));
                    }
                    else
                    {
                        var result = new[] { results.Pop(), results.Pop(), results.Pop(), results.Pop() }.Max();
                        results.Push(result);
                    }

                    break;

                case Direction.Left:
                    if (!isCalculated)
                    {
                        stack.Push((node.left, Direction.Right, false));
                    }
                    else
                    {
                        results.Push(1 + results.Pop());
                    }
                    break;

                case Direction.Right:
                    if (!isCalculated)
                    {
                        stack.Push((node.right, Direction.Left, false));
                    }
                    else
                    {
                        results.Push(1 + results.Pop());
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return results.Pop();
    }

    private enum Direction
    {
        Unknown,
        Left,
        Right
    }
}