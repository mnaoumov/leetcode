namespace LeetCode.Problems._0800_Similar_RGB_Color;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SimilarRGB(testCase.Color), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Color { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
