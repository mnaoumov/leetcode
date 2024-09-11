namespace LeetCode.Problems._0371_Sum_of_Two_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetSum(testCase.A, testCase.B), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
