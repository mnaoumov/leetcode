using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0081_Search_in_Rotated_Sorted_Array_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Search(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}