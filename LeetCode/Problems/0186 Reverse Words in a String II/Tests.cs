namespace LeetCode.Problems._0186_Reverse_Words_in_a_String_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var s = testCase.S.ToArray();
        solution.ReverseWords(s);
        Assert.That(s, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[] S { get; [UsedImplicitly] init; } = null!;
        public char[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
