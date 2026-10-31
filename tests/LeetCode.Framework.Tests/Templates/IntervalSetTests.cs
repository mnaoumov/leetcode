using static LeetCode.Templates.IntervalSetTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class IntervalSetTests
{
    [Test]
    public void Add_MergesOverlappingAndTouching()
    {
        var set = new IntervalSet();
        set.Add(1, 3);
        set.Add(5, 7);
        set.Add(3, 5);
        Assert.That(set.Intervals, Is.EqualTo(new[] { (1L, 7L) }));
        Assert.That(set.TotalLength, Is.EqualTo(6));
    }

    [Test]
    public void Add_InsideExisting_NoChange()
    {
        var set = new IntervalSet();
        set.Add(0, 10);
        set.Add(2, 4);
        Assert.That(set.Intervals, Is.EqualTo(new[] { (0L, 10L) }));
    }

    [Test]
    public void Remove_Splits()
    {
        var set = new IntervalSet();
        set.Add(0, 10);
        set.Remove(3, 5);
        Assert.That(set.Intervals, Is.EqualTo(new[] { (0L, 3L), (5L, 10L) }));
        Assert.That(set.TotalLength, Is.EqualTo(8));
        Assert.That(set.Contains(3), Is.False);
        Assert.That(set.Contains(5), Is.True);
    }

    [Test]
    public void Covers_HalfOpen()
    {
        // 0715 Range Module.
        var set = new IntervalSet();
        set.Add(10, 20);
        set.Remove(14, 16);
        Assert.That(set.Covers(10, 14), Is.True);
        Assert.That(set.Covers(13, 15), Is.False);
        Assert.That(set.Covers(16, 17), Is.True);
        Assert.That(set.Covers(5, 5), Is.True);
    }

    [Test]
    public void EmptyRanges_AreIgnored()
    {
        var set = new IntervalSet();
        set.Add(5, 5);
        set.Remove(3, 1);
        Assert.That(set.Count, Is.EqualTo(0));
    }

    [Test]
    public void RandomOperations_MatchBruteForce()
    {
        var random = new Random(13);
        const int size = 40;
        var expected = new bool[size];
        var set = new IntervalSet();

        for (var operation = 0; operation < 3000; operation++)
        {
            var start = random.Next(size + 1);
            var end = random.Next(size + 1);
            (start, end) = (Math.Min(start, end), Math.Max(start, end));

            switch (random.Next(3))
            {
                case 0:
                    set.Add(start, end);
                    Array.Fill(expected, true, start, end - start);
                    break;
                case 1:
                    set.Remove(start, end);
                    Array.Fill(expected, false, start, end - start);
                    break;
                default:
                    Assert.That(set.Covers(start, end), Is.EqualTo(expected[start..end].All(covered => covered)));
                    break;
            }

            Assert.That(set.TotalLength, Is.EqualTo(expected.Count(covered => covered)));
            var intervals = set.Intervals.ToList();

            for (var i = 1; i < intervals.Count; i++)
            {
                Assert.That(intervals[i - 1].End, Is.LessThan(intervals[i].Start), "disjoint and not touching");
            }
        }
    }

    [Test]
    public void Merge_Static()
    {
        // 0056 Merge Intervals: closed intervals, so touching ones merge.
        var merged = Merge([(8, 10), (1, 3), (2, 6), (15, 18), (18, 20)]);
        Assert.That(merged, Is.EqualTo(new[] { (1L, 6L), (8L, 10L), (15L, 20L) }));
        Assert.That(Merge([]), Is.Empty);
    }
}
