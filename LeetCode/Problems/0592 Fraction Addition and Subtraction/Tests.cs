using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0592_Fraction_Addition_and_Subtraction;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FractionAddition(testCase.Expression), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Expression { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
