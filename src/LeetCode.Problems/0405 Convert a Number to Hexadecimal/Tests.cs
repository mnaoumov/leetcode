namespace LeetCode.Problems._0405_Convert_a_Number_to_Hexadecimal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ToHex(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
