using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3139_Minimum_Cost_to_Equalize_Array;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCostToEqualizeArray(testCase.Nums, testCase.Cost1, testCase.Cost2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Cost1 { get; [UsedImplicitly] init; }
        public int Cost2 { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
