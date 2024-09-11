namespace LeetCode.Problems._2525_Categorize_Box_According_to_Criteria;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CategorizeBox(testCase.Length, testCase.Width, testCase.Height, testCase.Mass), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Length { get; [UsedImplicitly] init; }
        public int Width { get; [UsedImplicitly] init; }
        public int Height { get; [UsedImplicitly] init; }
        public int Mass { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
