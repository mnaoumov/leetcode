using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0007_Reverse_Integer;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Reverse(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
