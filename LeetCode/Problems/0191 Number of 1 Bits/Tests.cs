namespace LeetCode.Problems._0191_Number_of_1_Bits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var n = Convert.ToUInt32(testCase.N, 2);
        Assert.That(solution.HammingWeight(n), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string N { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
