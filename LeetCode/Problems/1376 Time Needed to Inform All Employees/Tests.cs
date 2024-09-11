using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1376_Time_Needed_to_Inform_All_Employees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumOfMinutes(testCase.N, testCase.HeadID, testCase.Manager, testCase.InformTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int HeadID { get; [UsedImplicitly] init; }
        public int[] Manager { get; [UsedImplicitly] init; } = null!;
        public int[] InformTime { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
