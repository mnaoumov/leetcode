using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0072_Edit_Distance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDistance(testCase.Word1, testCase.Word2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Word1 { get; [UsedImplicitly] init; } = null!;
        public string Word2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
