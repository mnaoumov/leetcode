using static LeetCode.Templates.FenwickTreeTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class FenwickTreeTests
{
    [Test]
    public void PrefixSum_AfterAdds()
    {
        var tree = new FenwickTree(5);
        tree.Add(0, 1);
        tree.Add(2, 3);
        tree.Add(4, 5);
        Assert.That(tree.PrefixSum(0), Is.EqualTo(0));
        Assert.That(tree.PrefixSum(3), Is.EqualTo(4));
        Assert.That(tree.PrefixSum(5), Is.EqualTo(9));
        Assert.That(tree.Sum(1, 4), Is.EqualTo(3));
    }

    [Test]
    public void RandomOperations_MatchBruteForce()
    {
        var random = new Random(11);
        const int n = 37;
        var expected = new long[n];
        var tree = new FenwickTree(n);

        for (var operation = 0; operation < 2000; operation++)
        {
            if (random.Next(2) == 0)
            {
                var index = random.Next(n);
                var delta = random.Next(-100, 100);
                tree.Add(index, delta);
                expected[index] += delta;
            }
            else
            {
                var from = random.Next(n + 1);
                var to = random.Next(from, n + 1);
                Assert.That(tree.Sum(from, to), Is.EqualTo(expected[from..to].Sum()));
            }
        }
    }
}
