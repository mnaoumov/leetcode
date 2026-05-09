namespace LeetCode.Problems._3464_Maximize_the_Distance_Between_Points_on_a_Square;

/// <summary>
/// https://leetcode.com/problems/maximize-the-distance-between-points-on-a-square/submissions/1989010671/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int MaxDistance(int side, int[][] points, int k)
    {
        var pointObjs = points.Select(arr => new Point(arr[0], arr[1])).ToArray();
        var bottomXs = pointObjs.Where(p => p.Y == 0).Select(p => p.X).OrderBy(x => x).ToArray();
        var topXs = pointObjs.Where(p => p.Y == side).Select(p => p.X).OrderBy(x => x).ToArray();
        // ReSharper disable once MergeIntoPattern
        var leftYs = pointObjs.Where(p => p.X == 0 && 0 < p.Y && p.Y < side).Select(p => p.Y).OrderBy(y => y).ToArray();
        var rightYs = pointObjs.Where(p => p.X == side && 0 < p.Y && p.Y < side).Select(p => p.Y).OrderBy(y => y).ToArray();

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

        IEnumerable<Point> OrderedPoints()
        {
            foreach (var x in bottomXs)
            {
                yield return new Point(x, 0);
            }

            foreach (var y in rightYs)
            {
                yield return new Point(side, y);
            }

            foreach (var x in topXs.Reverse())
            {
                yield return new Point(x, side);
            }

            foreach (var y in leftYs.Reverse())
            {
                yield return new Point(0, y);
            }
        }

        bool CanSelectKPoints(int minDistance)
        {
            var isFirstStartingPoint = true;
            var stopPoint = new Point(int.MaxValue, int.MaxValue);

            foreach (var startPoint in OrderedPoints())
            {
                if (startPoint == stopPoint)
                {
                    break;
                }

                var point = startPoint;

                for (var i = 1; i < k; i++)
                {
                    var nextPoint = NextPoint(point, minDistance);

                    if (nextPoint == null)
                    {
                        return false;
                    }

                    if (point == startPoint && isFirstStartingPoint)
                    {
                        stopPoint = nextPoint;
                        isFirstStartingPoint = false;
                    }

                    point = nextPoint;
                }

                if (Math.Abs(point.X - startPoint.X) + Math.Abs(point.Y - startPoint.Y) >= minDistance)
                {
                    return true;
                }
            }

            return false;
        }

        Point? NextPoint(Point point, int minDistance)
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
                    return new Point(bottomXs[index], 0);
                }

                index = rightYs.BinarySearch(point.X + minDistance - side);

                if (index < 0)
                {
                    index = ~index;
                }

                if (index < rightYs.Length)
                {
                    return new Point(side, rightYs[index]);
                }

                if (topXs.Length > 0)
                {
                    return new Point(topXs[^1], side);
                }

                if (leftYs.Length > 0 && point.X + leftYs[^1] >= minDistance)
                {
                    return new Point(0, leftYs[^1]);
                }

                return null;
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
                    return new Point(side, rightYs[index]);
                }

                index = topXs.BinarySearch(2 * side - point.Y - minDistance);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (0 <= index && index < topXs.Length)
                {
                    return new Point(topXs[index], side);
                }

                if (leftYs.Length > 0)
                {
                    return new Point(0, leftYs[^1]);
                }

                return null;
            }

            if (point.Y == side)
            {
                var index = topXs.BinarySearch(point.X - minDistance);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (0 <= index && index < topXs.Length)
                {
                    return new Point(topXs[index], side);
                }

                index = leftYs.BinarySearch(point.X + side - minDistance);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (0 <= index && index < leftYs.Length)
                {
                    return new Point(0, leftYs[index]);
                }

                return null;
            }

            // ReSharper disable once InvertIf
            if (point.X == 0)
            {
                var index = leftYs.BinarySearch(point.Y - minDistance);

                if (index < 0)
                {
                    index = ~index - 1;
                }

                if (0 <= index && index < leftYs.Length)
                {
                    return new Point(0, leftYs[index]);
                }
            }

            return null;
        }
    }

    private sealed record Point(int X, int Y);
}
