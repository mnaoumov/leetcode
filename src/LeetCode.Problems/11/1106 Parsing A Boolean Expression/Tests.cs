namespace LeetCode.Problems._1106_Parsing_A_Boolean_Expression;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ParseBoolExpr(testCase.Expression), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Expression { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
