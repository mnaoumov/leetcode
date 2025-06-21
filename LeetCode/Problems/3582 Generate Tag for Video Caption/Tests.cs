namespace LeetCode.Problems._3582_Generate_Tag_for_Video_Caption;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateTag(testCase.Caption), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Caption { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
