using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2591_Distribute_Money_to_Maximum_Children;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DistMoney(testCase.Money, testCase.Children), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Money { get; [UsedImplicitly] init; }
        public int Children { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
