namespace LeetCode.Problems._3133_Minimum_Array_End;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinEnd(testCase.N, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int X { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
