using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._0000_Calculate_Entropy;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = solution.CalculateEntropy(testCase.Input);
        Assert.That(output, Is.EqualTo(testCase.Output).Within(1e-6));

        if (output == 0.0 && double.IsNegativeInfinity(1.0 / output) && !double.IsNegativeInfinity(testCase.Output))
        {
            Assert.Fail("Returned -0.0 instead of 0.0");
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Input { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
