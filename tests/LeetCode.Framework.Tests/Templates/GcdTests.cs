using static LeetCode.Templates.GcdTemplate;

namespace LeetCode.Framework.Tests.Templates;

public class GcdTests
{
    [Test]
    public void Gcd_Basic()
    {
        Assert.That(Gcd(12, 18), Is.EqualTo(6));
        Assert.That(Gcd(17, 5), Is.EqualTo(1));
        Assert.That(Gcd(0, 7), Is.EqualTo(7));
        Assert.That(Gcd(0, 0), Is.EqualTo(0));
    }

    [Test]
    public void Gcd_Negative_IsNonNegative()
    {
        Assert.That(Gcd(-12, 18), Is.EqualTo(6));
        Assert.That(Gcd(12, -18), Is.EqualTo(6));
    }

    [Test]
    public void Lcm_Basic()
    {
        Assert.That(Lcm(4, 6), Is.EqualTo(12));
        Assert.That(Lcm(0, 6), Is.EqualTo(0));
        Assert.That(Lcm(-4, 6), Is.EqualTo(12));
    }

    [Test]
    public void Lcm_LargeValues_DoesNotOverflowEarly()
    {
        Assert.That(Lcm(1_000_000_000_000L, 2_000_000_000_000L), Is.EqualTo(2_000_000_000_000L));
    }

    [Test]
    public void Gcd_Lcm_OfSequence()
    {
        Assert.That(Gcd([12L, 18, 30]), Is.EqualTo(6));
        Assert.That(Lcm([2L, 3, 4]), Is.EqualTo(12));
        Assert.That(Gcd(Array.Empty<long>()), Is.EqualTo(0));
        Assert.That(Lcm(Array.Empty<long>()), Is.EqualTo(1));
    }

    [Test]
    public void Digits_RoundTrip()
    {
        Assert.That(Digits(0), Is.EqualTo(new[] { 0 }));
        Assert.That(Digits(1203), Is.EqualTo(new[] { 1, 2, 0, 3 }));
        Assert.That(FromDigits([1, 2, 0, 3]), Is.EqualTo(1203));
        Assert.That(FromDigits(Digits(long.MaxValue)), Is.EqualTo(long.MaxValue));
    }
}
