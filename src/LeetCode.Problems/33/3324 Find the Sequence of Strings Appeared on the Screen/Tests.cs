namespace LeetCode.Problems._3324_Find_the_Sequence_of_Strings_Appeared_on_the_Screen;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.StringSequence(testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Target { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
