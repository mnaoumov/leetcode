namespace LeetCode.Problems._1580_Put_Boxes_Into_the_Warehouse_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxBoxesInWarehouse(testCase.Boxes, testCase.Warehouse), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Boxes { get; [UsedImplicitly] init; } = null!;
        public int[] Warehouse { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
