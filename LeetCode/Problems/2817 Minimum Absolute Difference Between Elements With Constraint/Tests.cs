using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2817_Minimum_Absolute_Difference_Between_Elements_With_Constraint;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinAbsoluteDifference(testCase.Nums, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Nums { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
