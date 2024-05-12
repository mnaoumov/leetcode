using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2351_First_Letter_to_Appear_Twice;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RepeatedCharacter(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public char Output { get; [UsedImplicitly] init; }
    }
}
