using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0587_Erect_the_Fence;

/// <summary>
/// https://leetcode.com/problems/erect-the-fence/submissions/846485938/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
{
    public int[][] OuterTrees(int[][] trees) => OuterTrees(trees.Select(Point.FromArray).ToArray()).Select(tree => tree.ToArray()).ToArray();

    private static IEnumerable<Point> OuterTrees(IReadOnlyCollection<Point> trees)
    {
        if (trees.Count <= 3)
        {
            return trees;
        }

        var minY = trees.Select(tree => tree.Y).Min();
        var bottomLeftTree = trees.Where(tree => tree.Y == minY).MinBy(tree => tree.X)!;

        var orderedTrees = trees
            .OrderByDescending(tree => new Vector(bottomLeftTree, tree).CosAngle)
            .ThenBy(tree => new Vector(bottomLeftTree, tree).Length)
            .ToArray();

        var stack = new Stack<Point>();
        stack.Push(orderedTrees[0]);
        stack.Push(orderedTrees[1]);

        foreach (var tree in orderedTrees.Skip(2))
        {
            while (true)
            {
                var lastTree = stack.Pop();
                var beforeLastTree = stack.Peek();
                var isLeftTurn = new Vector(beforeLastTree, lastTree).IsLeftTurn(new Vector(lastTree, tree));

                if (!isLeftTurn)
                {
                    continue;
                }

                stack.Push(lastTree);
                break;
            }

            stack.Push(tree);
        }

        var firstCosAngle = new Vector(bottomLeftTree, orderedTrees[1]).CosAngle;
        var lastCosAngle = new Vector(bottomLeftTree, orderedTrees[^1]).CosAngle;

        if (AreEqual(firstCosAngle, lastCosAngle))
        {
            return stack;
        }

        foreach (var tree in orderedTrees.Reverse().Skip(1))
        {
            if (AreEqual(new Vector(bottomLeftTree, tree).CosAngle, lastCosAngle))
            {
                stack.Push(tree);
            }
            else
            {
                break;
            }
        }

        return stack;
    }

    private static bool AreEqual(double double1, double double2)
    {
        const double epsilon = 1e-8;
        return Math.Abs(double1 - double2) < epsilon;
    }

    private record Point(int X, int Y)
    {
        public static Point FromArray(int[] arr) => new(arr[0], arr[1]);

        public int[] ToArray()
        {
            return new[] { X, Y };
        }
    }

    private record Vector(int X, int Y)
    {
        public Vector(Point start, Point end) : this(end.X - start.X, end.Y - start.Y)
        {
        }

        public double CosAngle => Length == 0 ? 1 : X / Length;
        public double Length => Math.Sqrt(X * X + Y * Y);
        public bool IsLeftTurn(Vector vector) => X * vector.Y - Y * vector.X >= 0;
    }
}
