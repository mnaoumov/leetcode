namespace LeetCode.Problems._3796_Find_Maximum_Value_in_a_Constrained_Sequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaxVal(testCase.N, testCase.Restrictions, testCase.Diff), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Restrictions { get; [UsedImplicitly] init; } = null!;
        public int[] Diff { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
