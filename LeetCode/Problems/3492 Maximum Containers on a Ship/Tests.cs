namespace LeetCode.Problems._3492_Maximum_Containers_on_a_Ship;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxContainers(testCase.N, testCase.W, testCase.MaxWeight), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int W { get; [UsedImplicitly] init; }
        public int MaxWeight { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
