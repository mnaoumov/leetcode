namespace LeetCode.Problems._1181_Before_and_After_Puzzle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BeforeAndAfterPuzzles(testCase.Phrases), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Phrases { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
