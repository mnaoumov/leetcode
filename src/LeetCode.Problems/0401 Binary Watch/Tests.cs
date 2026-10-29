namespace LeetCode.Problems._0401_Binary_Watch;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.ReadBinaryWatch(testCase.TurnedOn), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int TurnedOn { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
