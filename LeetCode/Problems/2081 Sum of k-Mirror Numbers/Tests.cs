namespace LeetCode.Problems._2081_Sum_of_k_Mirror_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KMirror(testCase.K, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
