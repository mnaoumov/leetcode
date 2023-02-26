using JetBrains.Annotations;

namespace LeetCode._1372_Longest_ZigZag_Path_in_a_Binary_Tree;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestZigZag(TreeNode root)
    {
        var stack = new Stack<(TreeNode? node, Direction direction)>();
        stack.Push((root, Direction.Unknown));
        var results = new Dictionary<(TreeNode? node, Direction direction), int>();

        while (stack.Count > 0)
        {
            var key = stack.Pop();
            var (node, direction) = key;

            if (results.ContainsKey(key))
            {
                continue;
            }

            if (node == null)
            {
                results[key] = -1;
                continue;
            }

            switch (direction)
            {
                case Direction.Unknown:
                    if (GetResult(node.left, Direction.Unknown) is { } x1
                        && GetResult(node.right, Direction.Unknown) is { } x2
                        && GetResult(node, Direction.Left) is { } x3
                        && GetResult(node, Direction.Right) is { } x4)
                    {
                        results[key] = new[] { x1, x2, x3, x4 }.Max();
                    }
                    else
                    {
                        stack.Push(key);
                    }
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
            }

            

        }

        return results[(root, Direction.Unknown)];

        int? GetResult(TreeNode? node, Direction direction) => results.TryGetValue((node, direction), out var result) ? result : null;
    }

    private enum Direction
    {
        Unknown,
        Left,
        Right
    }
}