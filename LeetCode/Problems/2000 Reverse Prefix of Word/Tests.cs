using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2000_Reverse_Prefix_of_Word;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReversePrefix(testCase.Word, testCase.Ch), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Word { get; [UsedImplicitly] init; } = null!;
        public char Ch { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
