namespace LeetCode.Problems._3747_Count_Distinct_Integers_After_Removing_Zeros;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountDistinct(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long N { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
