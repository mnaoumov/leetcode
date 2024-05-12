using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1196_How_Many_Apples_Can_You_Put_into_the_Basket;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxNumberOfApples(testCase.Weight), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Weight { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
