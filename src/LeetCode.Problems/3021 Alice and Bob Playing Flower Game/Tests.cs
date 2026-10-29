namespace LeetCode.Problems._3021_Alice_and_Bob_Playing_Flower_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FlowerGame(testCase.N, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
