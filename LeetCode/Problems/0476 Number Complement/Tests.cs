namespace LeetCode.Problems._0476_Number_Complement;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindComplement(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
