namespace LeetCode.Problems._3335_Total_Characters_in_String_After_Transformations_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LengthAfterTransformations(testCase.S, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int T { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
