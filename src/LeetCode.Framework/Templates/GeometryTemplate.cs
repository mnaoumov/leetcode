// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class GeometryTemplate
{
    // Integer coordinates, so every test is exact. A Point doubles as a vector (the difference of two points).
    public readonly record struct Point(long X, long Y)
    {
        public static Point operator +(Point point1, Point point2) => new(point1.X + point2.X, point1.Y + point2.Y);

        public static Point operator -(Point point1, Point point2) => new(point1.X - point2.X, point1.Y - point2.Y);

        /// <summary>&gt; 0 when other is counter-clockwise from this, &lt; 0 when clockwise, 0 when collinear.</summary>
        public long Cross(Point other) => X * other.Y - Y * other.X;

        public long Dot(Point other) => X * other.X + Y * other.Y;

        public long SquaredLength => X * X + Y * Y;

        /// <summary>&gt; 0 when o -&gt; a -&gt; b turns left (counter-clockwise), &lt; 0 when it turns right, 0 when collinear.</summary>
        public static long Orientation(Point o, Point a, Point b) => (a - o).Cross(b - o);
    }

    // Monotone chain, O(n log n). Counter-clockwise from the lowest-leftmost point, without repeats.
    // keepCollinear keeps the points lying on the hull's edges (as 0587 Erect the Fence needs).
    public static List<Point> ConvexHull(IEnumerable<Point> points, bool keepCollinear = false)
    {
        var sorted = points.Distinct().OrderBy(point => point.X).ThenBy(point => point.Y).ToList();

        if (sorted.Count <= 2)
        {
            return sorted;
        }

        var hull = new List<Point>();

        // Lower hull left to right, then upper hull right to left; lowerSize stops the upper pass popping the lower hull.
        for (var pass = 0; pass < 2; pass++)
        {
            var lowerSize = hull.Count;

            foreach (var point in pass == 0 ? sorted : Enumerable.Reverse(sorted))
            {
                while (hull.Count >= lowerSize + 2)
                {
                    var orientation = Point.Orientation(hull[^2], hull[^1], point);

                    if (orientation > 0 || keepCollinear && orientation == 0)
                    {
                        break;
                    }

                    hull.RemoveAt(hull.Count - 1);
                }

                hull.Add(point);
            }

            hull.RemoveAt(hull.Count - 1);
        }

        // When every point is collinear and kept, the upper pass walks the same points back; drop the repeats.
        return hull.Distinct().ToList();
    }

    // The line through two distinct points as A x + B y = C, normalised (gcd(A, B) = 1, A > 0 or A = 0 and B > 0),
    // so every pair of points on the same line gives an equal Line, usable as a dictionary key (0149 Max Points on a Line).
    public readonly record struct Line(long A, long B, long C)
    {
        public static Line Through(Point point1, Point point2)
        {
            var a = point2.Y - point1.Y;
            var b = point1.X - point2.X;
            var gcd = Gcd(Math.Abs(a), Math.Abs(b));
            a /= gcd;
            b /= gcd;

            if (a < 0 || a == 0 && b < 0)
            {
                a = -a;
                b = -b;
            }

            return new Line(a, b, a * point1.X + b * point1.Y);
        }

        public bool Contains(Point point) => A * point.X + B * point.Y == C;

        /// <summary>The normalised direction alone, equal for parallel lines.</summary>
        public (long A, long B) Slope => (A, B);

        private static long Gcd(long a, long b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }

            return a;
        }
    }
}
