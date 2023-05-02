using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0200_Number_of_Islands;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumIslands(testCase.Grid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
