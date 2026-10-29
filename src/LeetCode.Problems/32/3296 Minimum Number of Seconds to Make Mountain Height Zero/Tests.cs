namespace LeetCode.Problems._3296_Minimum_Number_of_Seconds_to_Make_Mountain_Height_Zero;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinNumberOfSeconds(testCase.MountainHeight, testCase.WorkerTimes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int MountainHeight { get; [UsedImplicitly] init; }
        public int[] WorkerTimes { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
