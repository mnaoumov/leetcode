using static LeetCode.Templates.PrimeSieveTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class PrimeSieveTests
{
    [Test]
    public void Primes_UpTo30()
    {
        var sieve = new PrimeSieve(30);
        Assert.That(sieve.Primes, Is.EqualTo(new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 }));
    }

    [Test]
    public void IsPrime_MatchesTrialDivision()
    {
        const int max = 10_000;
        var sieve = new PrimeSieve(max);

        for (var n = 0; n <= max; n++)
        {
            Assert.That(sieve.IsPrime(n), Is.EqualTo(IsPrime(n)), $"n = {n}");
        }
    }

    [Test]
    public void SmallestPrimeFactor()
    {
        var sieve = new PrimeSieve(100);
        Assert.That(sieve.SmallestPrimeFactor(1), Is.EqualTo(0));
        Assert.That(sieve.SmallestPrimeFactor(49), Is.EqualTo(7));
        Assert.That(sieve.SmallestPrimeFactor(97), Is.EqualTo(97));
        Assert.That(sieve.SmallestPrimeFactor(100), Is.EqualTo(2));
    }

    [Test]
    public void Factorise()
    {
        var sieve = new PrimeSieve(1000);
        Assert.That(sieve.Factorise(1), Is.Empty);
        Assert.That(sieve.Factorise(360), Is.EqualTo(new[] { (2, 3), (3, 2), (5, 1) }));
        Assert.That(sieve.Factorise(997), Is.EqualTo(new[] { (997, 1) }));
    }

    [Test]
    public void Factorise_MultipliesBack()
    {
        const int max = 5000;
        var sieve = new PrimeSieve(max);

        for (var n = 1; n <= max; n++)
        {
            var product = sieve.Factorise(n).Aggregate(1, (current, factor) => current * (int) Math.Pow(factor.Prime, factor.Exponent));
            Assert.That(product, Is.EqualTo(n), $"n = {n}");
        }
    }

    [Test]
    public void IsPrime_Long()
    {
        Assert.That(IsPrime(1), Is.False);
        Assert.That(IsPrime(2), Is.True);
        Assert.That(IsPrime(1_000_000_007), Is.True);
        Assert.That(IsPrime(1_000_000_007L * 3), Is.False);
    }

    [Test]
    public void Sieve_SmallMax()
    {
        Assert.That(new PrimeSieve(0).Primes, Is.Empty);
        Assert.That(new PrimeSieve(2).Primes, Is.EqualTo(new[] { 2 }));
    }
}
