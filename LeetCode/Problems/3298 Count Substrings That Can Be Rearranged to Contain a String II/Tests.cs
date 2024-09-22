namespace LeetCode.Problems._3298_Count_Substrings_That_Can_Be_Rearranged_to_Contain_a_String_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ValidSubstringCount(testCase.Word1, testCase.Word2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Word1 { get; [UsedImplicitly] init; } = null!;
        public string Word2 { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
