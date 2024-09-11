using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3100_Water_Bottles_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxBottlesDrunk(testCase.NumBottles, testCase.NumExchange), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int NumBottles { get; [UsedImplicitly] init; }
        public int NumExchange { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
