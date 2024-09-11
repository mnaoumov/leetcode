using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2449_Minimum_Number_of_Operations_to_Make_Arrays_Similar;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeSimilar(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Target { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
