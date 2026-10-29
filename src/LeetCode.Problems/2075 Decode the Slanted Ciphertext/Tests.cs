namespace LeetCode.Problems._2075_Decode_the_Slanted_Ciphertext;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DecodeCiphertext(testCase.EncodedText, testCase.Rows), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string EncodedText { get; [UsedImplicitly] init; } = null!;
        public int Rows { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
