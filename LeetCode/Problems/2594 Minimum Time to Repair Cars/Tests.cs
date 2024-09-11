using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2594_Minimum_Time_to_Repair_Cars;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RepairCars(testCase.Ranks, testCase.Cars), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Ranks { get; [UsedImplicitly] init; } = null!;
        public int Cars { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
