namespace LeetCode.Problems._100355_Find_Maximum_Removals_From_Source_String;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxRemovals(testCase.Source, testCase.Pattern, testCase.TargetIndices), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Source { get; [UsedImplicitly] init; } = null!;
        public string Pattern { get; [UsedImplicitly] init; } = null!;
        public int[] TargetIndices { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
