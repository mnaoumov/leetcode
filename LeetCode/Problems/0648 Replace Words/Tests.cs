using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0648_Replace_Words;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReplaceWords(testCase.Dictionary, testCase.Sentence), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<string> Dictionary { get; [UsedImplicitly] init; } = null!;
        public string Sentence { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
