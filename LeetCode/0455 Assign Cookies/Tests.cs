using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0455_Assign_Cookies;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindContentChildren(testCase.G, testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] G { get; [UsedImplicitly] init; } = null!;
        public int[] S { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
