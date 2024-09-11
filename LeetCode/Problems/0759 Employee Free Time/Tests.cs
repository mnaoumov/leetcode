using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;
using NUnit.Framework;

namespace LeetCode.Problems._0759_Employee_Free_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var intervals = testCase.Schedule.Select(arrays => arrays.Select(Interval.FromArray).ToArray())
            .ToArray<IList<Interval>>();
        var output = testCase.Output.Select(Interval.FromArray).ToArray();
        Assert.That(solution.EmployeeFreeTime(intervals), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][][] Schedule { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
