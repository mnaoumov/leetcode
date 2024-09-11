using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0727_Minimum_Window_Subsequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinWindow(testCase.S1, testCase.S2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S1 { get; [UsedImplicitly] init; } = null!;
        public string S2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
