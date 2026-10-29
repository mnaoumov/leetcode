namespace LeetCode.Problems._0587_Erect_the_Fence;

/// <summary>
/// https://leetcode.com/problems/erect-the-fence/submissions/846184329/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] OuterTrees(int[][] trees) => OuterTrees(trees.Select(Tree.FromArray).ToArray()).Distinct().Select(tree => tree.ToArray()).ToArray();

    private static IEnumerable<Tree> OuterTrees(Tree[] trees)
    {
        var data = trees.GroupBy(tree => tree.X)
            .Select(g => (x: g.Key, minY: g.Select(tree => tree.Y).Min(), maxY: g.Select(tree => tree.Y).Max()))
            .OrderBy(z => z.x)
            .ToArray();

        var minXData = data[0];
        var maxXData = data[^1];

        foreach (var tree in trees.Where(tree => tree.X == minXData.x))
        {
            yield return tree;
        }

        foreach (var tree in trees.Where(tree => tree.X == maxXData.x))
        {
            yield return tree;
        }

        var globalMaxY = data.Select(z => z.maxY).Max();
        var globalMinY = data.Select(z => z.minY).Min();

        var middleData = data[1..^1];

        var middleXsForGlobalMaxY = middleData.Where(z => z.maxY == globalMaxY).Select(z => z.x).ToArray();
        var middleXsForGlobalMinY = middleData.Where(z => z.minY == globalMinY).Select(z => z.x).ToArray();

        foreach (var x in middleXsForGlobalMaxY)
        {
            yield return new Tree(x, globalMaxY);
        }

        foreach (var x in middleXsForGlobalMinY)
        {
            yield return new Tree(x, globalMinY);
        }

        Line leftLine;
        Line rightLine;

        if (middleXsForGlobalMaxY.Any())
        {
            var minMiddleXForGlobalMaxY = middleXsForGlobalMaxY.Min();
            var maxMiddleXForGlobalMaxY = middleXsForGlobalMaxY.Max();

            leftLine = new Line(new Tree(minXData.x, minXData.maxY), new Tree(minMiddleXForGlobalMaxY, globalMaxY));
            rightLine = new Line(new Tree(maxXData.x, maxXData.maxY), new Tree(minMiddleXForGlobalMaxY, globalMaxY));

            foreach (var (x, _, maxY) in middleData)
            {
                var tree = new Tree(x, maxY);

                Line? line = null;

                if (x < minMiddleXForGlobalMaxY)
                {
                    line = leftLine;
                }
                else if (x > maxMiddleXForGlobalMaxY)
                {
                    line = rightLine;
                }

                if (line != null && line.Contains(tree))
                {
                    yield return tree;
                }
            }
        }

        if (!middleXsForGlobalMinY.Any())
        {
            yield break;
        }

        var minMiddleXForGlobalMinY = middleXsForGlobalMinY.Min();
        var maxMiddleXForGlobalMinY = middleXsForGlobalMinY.Max();

        leftLine = new Line(new Tree(minXData.x, minXData.minY), new Tree(minMiddleXForGlobalMinY, globalMaxY));
        rightLine = new Line(new Tree(maxXData.x, maxXData.minY), new Tree(maxMiddleXForGlobalMinY, globalMaxY));

        foreach (var (x, minY, _) in middleData)
        {
            var tree = new Tree(x, minY);

            Line? line = null;

            if (x < minMiddleXForGlobalMinY)
            {
                line = leftLine;
            }
            else if (x > maxMiddleXForGlobalMinY)
            {
                line = rightLine;
            }

            if (line != null && line.Contains(tree))
            {
                yield return tree;
            }
        }
    }

    private record Tree(int X, int Y)
    {
        public static Tree FromArray(int[] arr) => new(arr[0], arr[1]);

        public int[] ToArray()
        {
            return new[] { X, Y };
        }
    }

    private record Line(Tree Tree1, Tree Tree2)
    {
        public bool Contains(Tree tree) => (Tree2.X - Tree1.X) * (tree.Y - Tree1.Y) == (Tree2.Y - Tree1.Y) * (tree.X - Tree1.X);
    }
}
