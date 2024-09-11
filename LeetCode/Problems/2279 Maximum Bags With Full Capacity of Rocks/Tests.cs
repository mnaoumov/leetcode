namespace LeetCode.Problems._2279_Maximum_Bags_With_Full_Capacity_of_Rocks;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumBags(testCase.Capacity, testCase.Rocks, testCase.AdditionalRocks), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Capacity { get; [UsedImplicitly] init; } = null!;
        public int[] Rocks { get; [UsedImplicitly] init; } = null!;
        public int AdditionalRocks { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
