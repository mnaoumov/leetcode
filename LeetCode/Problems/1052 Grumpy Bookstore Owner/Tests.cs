using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1052_Grumpy_Bookstore_Owner;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSatisfied(testCase.Customers, testCase.Grumpy, testCase.Minutes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Customers { get; [UsedImplicitly] init; } = null!;
        public int[] Grumpy { get; [UsedImplicitly] init; } = null!;
        public int Minutes { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
