using static LeetCode.Templates.SegmentTreeTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class SegmentTreeTests
{
    [Test]
    public void Build_FromValues()
    {
        var tree = new SegmentTree([5, 1, 4, 2, 3]);
        Assert.That(tree.Sum(0, 5), Is.EqualTo(15));
        Assert.That(tree.Min(1, 4), Is.EqualTo(1));
        Assert.That(tree.Max(1, 4), Is.EqualTo(4));
        Assert.That(tree.Sum(2, 2), Is.EqualTo(0));
    }

    [Test]
    public void AssignThenAdd_Composes()
    {
        var tree = new SegmentTree(8);
        tree.Add(0, 8, 3);
        tree.Assign(2, 6, 10);
        tree.Add(0, 4, 1);
        // [4, 4, 11, 11, 10, 10, 3, 3]
        Assert.That(tree.Sum(0, 8), Is.EqualTo(56));
        Assert.That(tree.Max(0, 8), Is.EqualTo(11));
        Assert.That(tree.Min(2, 6), Is.EqualTo(10));
        Assert.That(tree.Sum(3, 5), Is.EqualTo(21));
    }

    [Test]
    public void RandomOperations_MatchBruteForce()
    {
        var random = new Random(3);

        foreach (var n in new[] { 1, 2, 7, 33 })
        {
            var expected = new long[n];
            var tree = new SegmentTree(n);

            for (var operation = 0; operation < 2000; operation++)
            {
                var from = random.Next(n + 1);
                var to = random.Next(n + 1);
                (from, to) = (Math.Min(from, to), Math.Max(from, to));
                var value = random.Next(-50, 50);

                switch (random.Next(3))
                {
                    case 0:
                        tree.Add(from, to, value);

                        for (var i = from; i < to; i++)
                        {
                            expected[i] += value;
                        }

                        break;
                    case 1:
                        tree.Assign(from, to, value);

                        for (var i = from; i < to; i++)
                        {
                            expected[i] = value;
                        }

                        break;
                    default:
                        var range = expected[from..to];
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
}
