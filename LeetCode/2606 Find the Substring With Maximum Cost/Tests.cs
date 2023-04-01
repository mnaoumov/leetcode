using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2606_Find_the_Substring_With_Maximum_Cost;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumCostSubstring(testCase.S, testCase.Chars, testCase.Vals), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string Chars { get; [UsedImplicitly] init; } = null!;
        public int[] Vals { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
