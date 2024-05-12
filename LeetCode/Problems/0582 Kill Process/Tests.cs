using JetBrains.Annotations;

namespace LeetCode.Problems._0582_Kill_Process;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.KillProcess(testCase.Pid, testCase.Ppid, testCase.Kill), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Pid { get; [UsedImplicitly] init; } = null!;
        public IList<int> Ppid { get; [UsedImplicitly] init; } = null!;
        public int Kill { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
