namespace LeetCode.Problems._2071_Maximum_Number_of_Tasks_You_Can_Assign;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxTaskAssign(testCase.Tasks, testCase.Workers, testCase.Pills, testCase.Strength), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Tasks { get; [UsedImplicitly] init; } = null!;
        public int[] Workers { get; [UsedImplicitly] init; } = null!;
        public int Pills { get; [UsedImplicitly] init; }
        public int Strength { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
