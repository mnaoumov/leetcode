using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0043_Multiply_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Multiply(testCase.Num1, testCase.Num2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Num1 { get; [UsedImplicitly] init; } = null!;
        public string Num2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
