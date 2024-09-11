using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3213_Construct_String_with_Minimum_Cost;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.Target, testCase.Words, testCase.Costs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Target { get; [UsedImplicitly] init; } = null!;
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int[] Costs { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
