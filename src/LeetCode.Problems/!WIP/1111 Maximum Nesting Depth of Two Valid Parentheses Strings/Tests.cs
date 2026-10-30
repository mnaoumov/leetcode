namespace LeetCode.Problems._1111_Maximum_Nesting_Depth_of_Two_Valid_Parentheses_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        // Any split is accepted that keeps both halves valid and the larger depth as small as the expected one's.
        var answer = solution.MaxDepthAfterSplit(testCase.Seq);

        Assert.That(answer, Has.Length.EqualTo(testCase.Seq.Length));
        Assert.That(answer, Is.All.InRange(0, 1));
        Assert.That(GetSplitDepth(testCase.Seq, answer), Is.EqualTo(GetSplitDepth(testCase.Seq, testCase.Output)));
    }

    private static int GetSplitDepth(string seq, int[] split)
    {
        var depths = new int[2];
        var maxDepth = 0;

        for (var i = 0; i < seq.Length; i++)
        {
            depths[split[i]] += seq[i] == '(' ? 1 : -1;
            Assert.That(depths[split[i]], Is.GreaterThanOrEqualTo(0), "A half is not a valid parentheses string");
            maxDepth = Math.Max(maxDepth, depths[split[i]]);
        }

        Assert.That(depths, Is.All.EqualTo(0), "A half is not a valid parentheses string");
        return maxDepth;
    }

    public class TestCase : TestCaseBase
    {
        public string Seq { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
