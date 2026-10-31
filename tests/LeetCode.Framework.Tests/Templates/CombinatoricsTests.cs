using static LeetCode.Templates.CombinatoricsTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class CombinatoricsTests
{
    [Test]
    public void Choose_MatchesPascalsTriangle()
    {
        const int max = 60;
        var combinatorics = new Combinatorics(max);
        var row = new long[] { 1 };

        for (var n = 0; n <= max; n++)
        {
            for (var k = 0; k <= n; k++)
            {
                Assert.That(combinatorics.Choose(n, k), Is.EqualTo(row[k]), $"C({n}, {k})");
            }

            var next = new long[n + 2];
            next[0] = next[n + 1] = 1;

            for (var k = 1; k <= n; k++)
            {
                next[k] = (row[k - 1] + row[k]) % Combinatorics.Modulo;
            }

            row = next;
        }
    }

    [Test]
    public void Choose_OutOfRange_IsZero()
    {
        var combinatorics = new Combinatorics(10);
        Assert.That(combinatorics.Choose(5, -1), Is.EqualTo(0));
        Assert.That(combinatorics.Choose(5, 6), Is.EqualTo(0));
    }

    [Test]
    public void Factorial_AndInverse()
    {
        var combinatorics = new Combinatorics(100_000);
        Assert.That(combinatorics.Factorial(5), Is.EqualTo(120));

        foreach (var n in new[] { 0, 1, 17, 99_999, 100_000 })
        {
            Assert.That(combinatorics.Factorial(n) * combinatorics.InverseFactorial(n) % Combinatorics.Modulo, Is.EqualTo(1));
        }
    }

    [Test]
    public void Permutations()
    {
        var combinatorics = new Combinatorics(10);
        Assert.That(combinatorics.Permutations(5, 2), Is.EqualTo(20));
        Assert.That(combinatorics.Permutations(5, 0), Is.EqualTo(1));
        Assert.That(combinatorics.Permutations(5, 6), Is.EqualTo(0));
    }

    [Test]
    public void Multichoose_StarsAndBars()
    {
        var combinatorics = new Combinatorics(20);
        Assert.That(combinatorics.Multichoose(3, 2), Is.EqualTo(4));
        Assert.That(combinatorics.Multichoose(0, 3), Is.EqualTo(1));
        Assert.That(combinatorics.Multichoose(0, 0), Is.EqualTo(1));
        Assert.That(combinatorics.Multichoose(3, 0), Is.EqualTo(0));
    }

    [Test]
    public void Pow_AndInverse()
    {
        Assert.That(Combinatorics.Pow(2, 10), Is.EqualTo(1024));
        Assert.That(Combinatorics.Pow(-2, 3), Is.EqualTo(Combinatorics.Modulo - 8));
        Assert.That(Combinatorics.Inverse(2) * 2 % Combinatorics.Modulo, Is.EqualTo(1));
    }
}
