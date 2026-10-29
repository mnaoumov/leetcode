using LeetCode.Templates;

namespace LeetCode.Tests.Templates;

public class DynamicProgrammingTests
{
    [Test]
    public void GetOrCalculate_ComputesAndCachesResult()
    {
        var callCount = 0;
        var dp = new DynamicProgrammingTemplate.DynamicProgramming<int, int>((key, _) =>
        {
            callCount++;
            return key * 2;
        });

        Assert.That(dp.GetOrCalculate(5), Is.EqualTo(10));
        Assert.That(dp.GetOrCalculate(5), Is.EqualTo(10));
        Assert.That(callCount, Is.EqualTo(1));
    }

    [Test]
    public void GetOrCalculate_RecursiveComputation()
    {
        // Fibonacci
        var dp = new DynamicProgrammingTemplate.DynamicProgramming<int, long>((key, getOrCalculate) =>
            key <= 1 ? key : getOrCalculate(key - 1) + getOrCalculate(key - 2));

        Assert.That(dp.GetOrCalculate(0), Is.EqualTo(0));
        Assert.That(dp.GetOrCalculate(1), Is.EqualTo(1));
        Assert.That(dp.GetOrCalculate(10), Is.EqualTo(55));
        Assert.That(dp.GetOrCalculate(20), Is.EqualTo(6765));
    }

    [Test]
    public void GetOrCalculate_TupleKeys()
    {
        var dp = new DynamicProgrammingTemplate.DynamicProgramming<(int, int), int>(
            (key, _) => key.Item1 + key.Item2);

        Assert.That(dp.GetOrCalculate((3, 4)), Is.EqualTo(7));
        Assert.That(dp.GetOrCalculate((1, 2)), Is.EqualTo(3));
    }
}
