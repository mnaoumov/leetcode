namespace LeetCode.Problems._0344_Reverse_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var s = testCase.S.ToArray();
        solution.ReverseString(s);
        Assert.That(s, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[] S { get; [UsedImplicitly] init; } = null!;
        public char[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
