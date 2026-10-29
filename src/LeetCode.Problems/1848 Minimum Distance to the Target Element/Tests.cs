namespace LeetCode.Problems._1848_Minimum_Distance_to_the_Target_Element;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetMinDistance(testCase.Nums, testCase.Target, testCase.Start), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int Start { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
