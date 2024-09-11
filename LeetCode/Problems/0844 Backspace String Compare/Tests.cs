using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0844_Backspace_String_Compare;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BackspaceCompare(testCase.S, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string T { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
