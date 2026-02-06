namespace LeetCode.Problems._1455_Check_If_a_Word_Occurs_As_a_Prefix_of_Any_Word_in_a_Sentence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPrefixOfWord(testCase.Sentence, testCase.SearchWord), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Sentence { get; [UsedImplicitly] init; } = null!;
        public string SearchWord { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
