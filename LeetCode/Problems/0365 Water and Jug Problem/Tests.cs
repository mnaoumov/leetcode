using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0365_Water_and_Jug_Problem;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanMeasureWater(testCase.Jug1Capacity, testCase.Jug2Capacity, testCase.TargetCapacity), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Jug1Capacity { get; [UsedImplicitly] init; }
        public int Jug2Capacity { get; [UsedImplicitly] init; }
        public int TargetCapacity { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
