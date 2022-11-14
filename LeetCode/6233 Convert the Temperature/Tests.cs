using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6233_Convert_the_Temperature;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ConvertTemperature(testCase.Celsius), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public double Celsius { get; [UsedImplicitly] init; }
        public double[] Output { get; [UsedImplicitly] init; } = null!;
    }
}