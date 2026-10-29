namespace LeetCode.Problems._1496_Path_Crossing;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPathCrossing(testCase.Path), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Path { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
