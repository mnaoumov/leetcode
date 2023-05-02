using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0838_Push_Dominoes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PushDominoes(testCase.Dominoes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Dominoes { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
