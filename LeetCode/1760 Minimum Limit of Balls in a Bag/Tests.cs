using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1760_Minimum_Limit_of_Balls_in_a_Bag;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumSize(testCase.Nums, testCase.MaxOperations), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int MaxOperations { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
