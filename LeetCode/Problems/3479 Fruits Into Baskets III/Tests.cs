namespace LeetCode.Problems._3479_Fruits_Into_Baskets_III;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumOfUnplacedFruits(testCase.Fruits, testCase.Baskets), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Fruits { get; [UsedImplicitly] init; } = null!;
        public int[] Baskets { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
