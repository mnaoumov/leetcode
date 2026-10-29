using LeetCode.Templates;

namespace LeetCode.Tests.Templates;

public class ModNumberTests
{
    private const int Mod = 1_000_000_007;

    [Test]
    public void ImplicitConversion_SmallValue()
    {
        ModNumberTemplate.ModNumber num = 42;
        Assert.That((int)num, Is.EqualTo(42));
    }

    [Test]
    public void ImplicitConversion_LargeValue_AppliesMod()
    {
        ModNumberTemplate.ModNumber num = Mod + 1;
        Assert.That((int)num, Is.EqualTo(1));
    }

    [Test]
    public void Addition_Basic()
    {
        ModNumberTemplate.ModNumber a = 3;
        ModNumberTemplate.ModNumber b = 4;
        Assert.That((int)(a + b), Is.EqualTo(7));
    }

    [Test]
    public void Addition_WithOverflow()
    {
        ModNumberTemplate.ModNumber a = Mod - 1;
        ModNumberTemplate.ModNumber b = 2;
        Assert.That((int)(a + b), Is.EqualTo(1));
    }

    [Test]
    public void Subtraction_Basic()
    {
        ModNumberTemplate.ModNumber a = 10;
        ModNumberTemplate.ModNumber b = 3;
        Assert.That((int)(a - b), Is.EqualTo(7));
    }

    [Test]
    public void Subtraction_Negative_WrapsAround()
    {
        ModNumberTemplate.ModNumber a = 3;
        ModNumberTemplate.ModNumber b = 10;
        Assert.That((int)(a - b), Is.EqualTo(Mod - 7));
    }

    [Test]
    public void Multiplication_Basic()
    {
        ModNumberTemplate.ModNumber a = 6;
        ModNumberTemplate.ModNumber b = 7;
        Assert.That((int)(a * b), Is.EqualTo(42));
    }

    [Test]
    public void Multiplication_LargeValues()
    {
        ModNumberTemplate.ModNumber a = 500_000_000;
        ModNumberTemplate.ModNumber b = 3;
        Assert.That((int)(a * b), Is.EqualTo((int)(1_500_000_000L % Mod)));
    }

    [Test]
    public void Division_Basic()
    {
        // a / b means a * modular_inverse(b)
        // 6 / 2 = 3
        ModNumberTemplate.ModNumber a = 6;
        ModNumberTemplate.ModNumber b = 2;
        Assert.That((int)(a / b), Is.EqualTo(3));
    }

    [Test]
    public void Division_ByZero_Throws()
    {
        ModNumberTemplate.ModNumber a = 5;
        ModNumberTemplate.ModNumber b = 0;
        Assert.Throws<DivideByZeroException>(() => { _ = a / b; });
    }

    [Test]
    public void Pow_Basic()
    {
        // 2^10 = 1024
        Assert.That((int)ModNumberTemplate.ModNumber.Pow(2, 10), Is.EqualTo(1024));
    }

    [Test]
    public void Pow_LargeExponent()
    {
        // 2^30 = 1073741824, mod 10^9+7 = 73741817
        Assert.That((int)ModNumberTemplate.ModNumber.Pow(2, 30), Is.EqualTo((int)(1_073_741_824L % Mod)));
    }

    [Test]
    public void Sum_MultipleValues()
    {
        ModNumberTemplate.ModNumber[] values = [1, 2, 3, 4, 5];
        Assert.That((int)ModNumberTemplate.ModNumber.Sum(values), Is.EqualTo(15));
    }

    [Test]
    public void ToString_ReturnsValue()
    {
        ModNumberTemplate.ModNumber num = 42;
        Assert.That(num.ToString(), Is.EqualTo("42"));
    }

    [Test]
    public void Division_Roundtrip()
    {
        // (a * b) / b == a
        ModNumberTemplate.ModNumber a = 12345;
        ModNumberTemplate.ModNumber b = 67890;
        Assert.That((int)(a * b / b), Is.EqualTo(12345));
    }
}
