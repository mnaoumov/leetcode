namespace LeetCode.Problems._0657_Robot_Return_to_Origin;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.JudgeCircle(testCase.Moves), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Moves { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
