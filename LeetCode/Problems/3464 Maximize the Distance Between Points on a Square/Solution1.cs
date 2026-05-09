namespace LeetCode.Problems._3464_Maximize_the_Distance_Between_Points_on_a_Square;

/// <summary>
/// https://leetcode.com/problems/maximize-the-distance-between-points-on-a-square/submissions/1988398011/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxDistance(int side, int[][] points, int k)
    {
        var pointObjs = points.Select(arr => new Point(arr[0], arr[1])).ToArray();
        var bottomXs = pointObjs.Where(p => p.Y == 0).Select(p => p.X).OrderBy(x => x).ToArray();
        var topXs = pointObjs.Where(p => p.Y == side).Select(p => p.X).OrderBy(x => x).ToArray();
        // ReSharper disable once MergeIntoPattern
        var leftYs = pointObjs.Where(p => p.Y == 0 && 0 < p.X && p.X < side).Select(p => p.Y).OrderBy(y => y).ToArray();
        var rightYs = pointObjs.Where(p => p.Y == side && 0 < p.X && p.X < side).Select(p => p.Y).OrderBy(y => y).ToArray();

        Point startPoint;

        if (bottomXs.Length > 0)
        {
            startPoint = new Point(bottomXs[0], 0);
        }
        else if (rightYs.Length > 0)
        {
            startPoint = new Point(side, rightYs[0]);
        }
        else if (topXs.Length > 0)
        {
            startPoint = new Point(topXs[^1], side);
        }
        else if (leftYs.Length > 0)
        {
            startPoint = new Point(0, leftYs[^1]);
        }
        else
        {
            throw new InvalidOperationException("Wrong points");
        }

        var low = 1;
        var high = side;

        while (low <= high)
        {
            var mid = (low + high) / 2;

            if (CanSelectKPoints(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high == 0 ? 1 : high;

        bool CanSelectKPoints(int minDistance)
        {
            var point = startPoint;

            for (var i = 1; i < k; i++)
            {
                if (point.Y == 0)
                {
                    var index = bottomXs.BinarySearch(point.X + minDistance);

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    if (index < bottomXs.Length)
                    {
                        point = new Point(bottomXs[index], 0);
                        continue;
                    }

                    index = rightYs.BinarySearch(point.X + minDistance - side);

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    if (index < rightYs.Length)
                    {
                        point = new Point(side, rightYs[index]);
                        continue;
                    }

                    if (topXs.Length > 0)
                    {
                        point = new Point(topXs[^1], side);
                        continue;
                    }

                    if (leftYs.Length > 0 && point.X + leftYs[^1] >= minDistance)
                    {
                        point = new Point(0, leftYs[^1]);
                        continue;
                    }

                    return false;
                }

                if (point.X == side)
                {
                    var index = rightYs.BinarySearch(point.Y + minDistance);

                    if (index < 0)
                    {
                        index = ~index;
                    }

                    if (index < rightYs.Length)
                    {
                        point = new Point(side, rightYs[index]);
                        continue;
                    }

                    index = topXs.BinarySearch(2 * side - point.Y - minDistance);

                    if (index < 0)
                    {
                        index = ~index - 1;
                    }

                    if (0 <= index && index < topXs.Length)
                    {
                        point = new Point(topXs[index], side);
                        continue;
                    }

                    if (leftYs.Length > 0)
                    {
                        point = new Point(0, leftYs[^1]);
                        continue;
                    }

                    return false;
                }

                if (point.Y == side)
                {
                    var index = bottomXs.BinarySearch(point.X - minDistance);

                    if (index < 0)
                    {
                        index = ~index - 1;
                    }

                    if (0 < index && index < bottomXs.Length)
                    {
                        point = new Point(bottomXs[index], side);
                        continue;
                    }

                    index = leftYs.BinarySearch(point.X + side - minDistance);

                    if (index < 0)
                    {
                        index = ~index - 1;
                    }

                    if (0 < index && index < leftYs.Length)
                    {
                        point = new Point(0, leftYs[index]);
                        continue;
                    }

                    return false;
                }

                // ReSharper disable once InvertIf
                if (point.X == 0)
                {
                    var index = leftYs.BinarySearch(point.Y - minDistance);

                    if (index < 0)
                    {
                        index = ~index - 1;
                    }

                    if (0 < index && index < bottomXs.Length)
                    {
                        point = new Point(0, leftYs[index]);
                        continue;
                    }

                    return false;
                }
            }

            return true;
        }
    }

    private sealed record Point(int X, int Y);
}
