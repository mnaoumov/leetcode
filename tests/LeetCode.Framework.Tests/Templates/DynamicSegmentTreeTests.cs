using static LeetCode.Templates.DynamicSegmentTreeTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class DynamicSegmentTreeTests
{
    [Test]
    public void HugeCoordinates_NoCompression()
    {
        var tree = new DynamicSegmentTree(0, 1_000_000_000);
        tree.Add(10, 500_000_000, 2);
        tree.Assign(400_000_000, 600_000_000, 7);
        Assert.That(tree.Sum(0, 1_000_000_000), Is.EqualTo(2L * 399_999_990 + 7L * 200_000_000));
        Assert.That(tree.Max(0, 1_000_000_000), Is.EqualTo(7));
        Assert.That(tree.Min(10, 400_000_000), Is.EqualTo(2));
        Assert.That(tree.Min(0, 1_000_000_000), Is.EqualTo(0));
    }

    [Test]
    public void NegativeLowerBound()
    {
        var tree = new DynamicSegmentTree(-100, 100);
        tree.Add(-50, 0, 1);
        Assert.That(tree.Sum(-100, 100), Is.EqualTo(50));
        Assert.That(tree.Sum(-1, 1), Is.EqualTo(1));
    }

    [Test]
    public void RandomOperations_MatchBruteForce()
    {
        var random = new Random(5);
        const int low = -20;
        const int high = 45;
        var expected = new long[high - low];
        var tree = new DynamicSegmentTree(low, high);

        for (var operation = 0; operation < 3000; operation++)
        {
            var from = random.Next(low, high + 1);
            var to = random.Next(low, high + 1);
            (from, to) = (Math.Min(from, to), Math.Max(from, to));
            var value = random.Next(-50, 50);

            switch (random.Next(3))
            {
                case 0:
                    tree.Add(from, to, value);

                    for (var i = from; i < to; i++)
                    {
                        expected[i - low] += value;
                    }

                    break;
                case 1:
                    tree.Assign(from, to, value);

                    for (var i = from; i < to; i++)
                    {
                        expected[i - low] = value;
                    }

                    break;
                default:
                    var range = expected[(from - low)..(to - low)];
                    Assert.That(tree.Sum(from, to), Is.EqualTo(range.Sum()));

                    if (range.Length > 0)
                    {
                        Assert.That(tree.Min(from, to), Is.EqualTo(range.Min()));
                        Assert.That(tree.Max(from, to), Is.EqualTo(range.Max()));
                    }

                    break;
            }
        }
    }
}
