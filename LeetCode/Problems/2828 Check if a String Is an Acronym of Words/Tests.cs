using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2828_Check_if_a_String_Is_an_Acronym_of_Words;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsAcronym(testCase.Words, testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<string> Words { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
