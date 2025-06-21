namespace LeetCode.Problems._1298_Maximum_Candies_You_Can_Get_from_Boxes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxCandies(testCase.Status, testCase.Candies, testCase.Keys, testCase.ContainedBoxes, testCase.InitialBoxes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Status { get; [UsedImplicitly] init; } = null!;
        public int[] Candies { get; [UsedImplicitly] init; } = null!;
        public int[][] Keys { get; [UsedImplicitly] init; } = null!;
        public int[][] ContainedBoxes { get; [UsedImplicitly] init; } = null!;
        public int[] InitialBoxes { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
