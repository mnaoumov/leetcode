namespace LeetCode.Problems._1405_Longest_Happy_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        // Any happy string is accepted as long as it is as long as the expected one.
        var answer = solution.LongestDiverseString(testCase.A, testCase.B, testCase.C);

        Assert.That(answer, Has.Length.EqualTo(testCase.Output.Length));
        Assert.That(answer, Does.Match("^[abc]*$"));
        Assert.That(answer, Does.Not.Contain("aaa").And.Not.Contain("bbb").And.Not.Contain("ccc"));
        Assert.That(answer.Count(letter => letter == 'a'), Is.LessThanOrEqualTo(testCase.A));
        Assert.That(answer.Count(letter => letter == 'b'), Is.LessThanOrEqualTo(testCase.B));
        Assert.That(answer.Count(letter => letter == 'c'), Is.LessThanOrEqualTo(testCase.C));
    }

    public class TestCase : TestCaseBase
    {
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int C { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
