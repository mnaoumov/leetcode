namespace LeetCode.Problems._3726_Remove_Zeros_in_Decimal_Representation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveZeros(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
