using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2600_K_Items_With_the_Maximum_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KItemsWithMaximumSum(testCase.NumOnes, testCase.NumZeros, testCase.NumNegOnes, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int NumOnes { get; [UsedImplicitly] init; }
        public int NumZeros { get; [UsedImplicitly] init; }
        public int NumNegOnes { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
