namespace LeetCode.Problems._2939_Maximum_Xor_Product;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumXorProduct(testCase.A, testCase.B, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long A { get; [UsedImplicitly] init; }
        public long B { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
