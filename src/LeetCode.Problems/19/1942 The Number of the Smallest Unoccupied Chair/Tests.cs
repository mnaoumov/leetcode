namespace LeetCode.Problems._1942_The_Number_of_the_Smallest_Unoccupied_Chair;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestChair(testCase.Times, testCase.TargetFriend), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Times { get; [UsedImplicitly] init; } = null!;
        public int TargetFriend { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
