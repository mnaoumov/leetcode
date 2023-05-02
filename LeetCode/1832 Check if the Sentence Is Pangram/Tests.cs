using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1832_Check_if_the_Sentence_Is_Pangram;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckIfPangram(testCase.Sentence), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Sentence { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
