using static LeetCode.Templates.GeometryTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class GeometryTests
{
    [Test]
    public void Point_Arithmetic()
    {
        var a = new Point(1, 2);
        var b = new Point(3, 5);
        Assert.That(a + b, Is.EqualTo(new Point(4, 7)));
        Assert.That(b - a, Is.EqualTo(new Point(2, 3)));
        Assert.That(a.Dot(b), Is.EqualTo(13));
        Assert.That(a.Cross(b), Is.EqualTo(-1));
        Assert.That(b.SquaredLength, Is.EqualTo(34));
    }

    [Test]
    public void Orientation()
    {
        var o = new Point(0, 0);
        Assert.That(Point.Orientation(o, new Point(1, 0), new Point(1, 1)), Is.Positive);
        Assert.That(Point.Orientation(o, new Point(1, 0), new Point(1, -1)), Is.Negative);
        Assert.That(Point.Orientation(o, new Point(1, 1), new Point(2, 2)), Is.Zero);
    }

    [Test]
    public void ConvexHull_Square_DropsInteriorAndEdgePoints()
    {
        var points = new[] { new Point(0, 0), new Point(2, 0), new Point(2, 2), new Point(0, 2), new Point(1, 1), new Point(1, 0) };
        Assert.That(ConvexHull(points), Is.EqualTo(new[] { new Point(0, 0), new Point(2, 0), new Point(2, 2), new Point(0, 2) }));
    }

    [Test]
    public void ConvexHull_KeepCollinear_KeepsEdgePoints()
    {
        // 0587 Erect the Fence, example 1.
        var points = new[] { new Point(1, 1), new Point(2, 2), new Point(2, 0), new Point(2, 4), new Point(3, 3), new Point(4, 2) };
        Assert.That(ConvexHull(points, keepCollinear: true),
            Is.EquivalentTo(new[] { new Point(1, 1), new Point(2, 0), new Point(4, 2), new Point(3, 3), new Point(2, 4) }));
    }

    [Test]
    public void ConvexHull_KeepCollinear_EveryEdgePoint()
    {
        var points = new List<Point>();

        for (var x = 0; x <= 3; x++)
        {
            for (var y = 0; y <= 3; y++)
            {
                points.Add(new Point(x, y));
            }
        }

        var hull = ConvexHull(points, keepCollinear: true);
        Assert.That(hull, Has.Count.EqualTo(12));
        Assert.That(hull, Does.Not.Contain(new Point(1, 1)));
    }

    [Test]
    public void ConvexHull_AllCollinear()
    {
        var points = new[] { new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3) };
        Assert.That(ConvexHull(points), Is.EqualTo(new[] { new Point(0, 0), new Point(3, 3) }));
        Assert.That(ConvexHull(points, keepCollinear: true), Is.EquivalentTo(points));
    }

    [Test]
    public void ConvexHull_FewPoints()
    {
        Assert.That(ConvexHull([]), Is.Empty);
        Assert.That(ConvexHull([new Point(1, 1), new Point(1, 1)]), Is.EqualTo(new[] { new Point(1, 1) }));
    }

    [Test]
    public void ConvexHull_IsCounterClockwise()
    {
        var random = new Random(17);
        var points = Enumerable.Range(0, 200).Select(_ => new Point(random.Next(-50, 50), random.Next(-50, 50))).ToList();
        var hull = ConvexHull(points);

        for (var i = 0; i < hull.Count; i++)
        {
            var a = hull[i];
            var b = hull[(i + 1) % hull.Count];

            foreach (var point in points)
            {
                Assert.That(Point.Orientation(a, b, point), Is.GreaterThanOrEqualTo(0));
            }
        }
    }

    [Test]
    public void Line_SameForEveryPairOnIt()
    {
        var line1 = Line.Through(new Point(0, 0), new Point(2, 4));
        var line2 = Line.Through(new Point(3, 6), new Point(1, 2));
        Assert.That(line1, Is.EqualTo(line2));
        Assert.That(line1.Contains(new Point(-1, -2)), Is.True);
        Assert.That(line1.Contains(new Point(1, 1)), Is.False);
    }

    [Test]
    public void Line_ParallelLinesShareSlopeOnly()
    {
        var line1 = Line.Through(new Point(0, 0), new Point(1, 1));
        var line2 = Line.Through(new Point(0, 1), new Point(1, 2));
        Assert.That(line1, Is.Not.EqualTo(line2));
        Assert.That(line1.Slope, Is.EqualTo(line2.Slope));
    }

    [Test]
    public void Line_HorizontalAndVertical()
    {
        Assert.That(Line.Through(new Point(5, 3), new Point(1, 3)), Is.EqualTo(new Line(0, 1, 3)));
        Assert.That(Line.Through(new Point(2, 7), new Point(2, -1)), Is.EqualTo(new Line(1, 0, 2)));
    }
}
